var autoprefixer = require("autoprefixer"),
    babel        = require("babel-core"),
    browserSync  = require("browser-sync").create(),
    cssnano      = require("cssnano"),
    del          = require("del"),
    gulp         = require("gulp"),
    jade         = require("gulp-jade"),
    iconfont     = require('gulp-iconfont'),
    consolidate  = require("gulp-consolidate"),
    concat       = require("gulp-concat"),
    postcss      = require("gulp-postcss"),
    sass         = require("gulp-sass"),
    sourcemaps   = require("gulp-sourcemaps"),
    watch        = require("gulp-watch"),
    streamify    = require("gulp-streamify"),
    uglify       = require("gulp-uglify"),
    gutil        = require("gulp-util"),
    plumber      = require("gulp-plumber"),
    imageMin     = require("gulp-imagemin"),
    runSequence  = require('run-sequence'),
    validator    = require("gulp-html-validator"),
    w3cjs        = require("gulp-w3cjs"),
    webpack      = require("webpack");

var optimize = false;

var paths = {
    bower   : "./bower_components/",
    images  : "./images/",
    fonts   : "./fonts/",
    sass    : "./sass/",
    js      : "././js/",
    jade    : "./jade/",
    dist    : "./dist/",
    css     : "./css/"
};
var onError = function (err) {
    gutil.beep();
    console.log(err);
};
gulp.task("sass", function () {
    var processors = [
        autoprefixer({
             browsers: ["last 3 version"]
        })
    ];
    if (optimize) {
        processors.push(cssnano({ safe: true, convertValues: false }));
    }
    return gulp.src(paths.sass + "*.scss")
      .pipe(sourcemaps.init())
      .pipe(sass({
          includePaths: [
              paths.sass,
              paths.sass + "blocks/",
              paths.bower + "bootstrap-sass/assets/stylesheets/"
          ]
      }).on("error", sass.logError))
      .pipe(postcss(processors))
      .pipe(sourcemaps.write("."))
      .pipe(gulp.dest(paths.css))
      .pipe(browserSync.stream({ match: '**/*.css' }));
});
gulp.task("js", function (done) {
    var plugins = [
        //new webpack.IgnorePlugin(/^\.\/locale$/, /moment$/)//work-around for issue where all moment.js's locales are loaded https://github.com/webpack/webpack/issues/198
    ];
    if (optimize) {
        plugins.push(new webpack.optimize.UglifyJsPlugin());
    }
    webpack({
        entry: {
            //index: paths.js + "index.js",
            common: paths.js + "common.js",
            map: paths.js + "map.js"
        },
        output: {
            filename: paths.dist + "js/[name].min.js"
        },
        devtool: optimize ? null : "inline-source-map",//TODO:disable for release build
        plugins: plugins,
        stats: {
            colors: true
        },
        module: {
            loaders: [
                { test: /\.js$/, loader: "babel-loader", query: { presets: ["es2015"] }, exclude: /(node_modules|bower_components)/ },
                { test: /\.js$/, loader: "eslint-loader", query: { parser: "babel-eslint" }, exclude: /(node_modules|bower_components)/ }
            ]
        }
    }, function (err, stats) {
        if (err) {
            throw new gutil.PluginError("webpack", err);
        }
        gutil.log("[webpack]", stats.toString({colors: true}));
    });
    done();
});

gulp.task("jade", function () {
    return gulp.src([paths.jade + "**/[^_]*.jade"])
        .pipe(plumber({
            errorHandler:onError
        }))
        .pipe(jade({
            pretty: true
        }))
        .pipe(w3cjs())
        .pipe(gulp.dest(paths.dist));
});

gulp.task("jquery-js", function () {
    return gulp.src([
        paths.bower + "jquery/dist/jquery.min.js"
    ])
    .pipe(concat("jquery.min.js"))
    .pipe(gulp.dest(paths.dist + "js/"));
});

gulp.task("vendor-js", function () {
    return gulp.src([
        paths.bower + "jquery-ui/jquery-ui.js",
        paths.bower + "bootstrap-sass/assets/javascripts/bootstrap.min.js",
    ])
    .pipe(concat("vendor.min.js"))
    .pipe(gulp.dest(paths.dist + "js/"));
});

/*gulp.task("vendor-css", function () {
    return gulp.src([
        paths.bower + "owl-carousel2/dist/assets/owl.carousel.css",
        paths.bower + "owl-carousel2/dist/assets/owl.theme.default.css",
        paths.bower + "swiper/dist/css/swiper.min.css",
        paths.bower + "animate.css/animate.min.css",
        "./css/mashup-ra-collection.css"
    ])
    .pipe(concat("vendor.min.css"))
    .pipe(gulp.dest(paths.dist + "css/"));
});*/

gulp.task("images", function() {
    return gulp.src([paths.images + "**/*.*", paths.images + "**/*"])
//        .pipe(imageMin({
//            progressive: true,
//            svgoPlugins: [{ removeViewBox: false }]
//        }))
        .pipe(gulp.dest(paths.dist + "images/"));
});

gulp.task("css", function() {
    return gulp.src([paths.css + "**/*.*", paths.css + "**/*"])
//        .pipe(imageMin({
//            progressive: true,
//            svgoPlugins: [{ removeViewBox: false }]
//        }))
        .pipe(gulp.dest(paths.dist + "css/"));
});

gulp.task("fonts", ["icon-fonts"], function () {
    return gulp.src(paths.fonts + "*")
        .pipe(gulp.dest(paths.dist + "fonts/"));
});

/*gulp.task("icon-fonts", function () {
    return gulp.src(paths.images + "icons/*.svg")
        .pipe(iconfont({
            fontName: "site-icons",
            appendUnicode: true,
            formats: ['ttf', 'eot', 'woff', 'woff2', 'svg'],
            timestamp: Math.round(Date.now() / 1000),
            normalize:true
        }))
        .on("glyphs", function (glyphs, options) {
            return gulp.src('./templates/_icons.scss')
                .pipe(consolidate('lodash', {
                    glyphs: glyphs,
                    fontName: options.fontName,
                    fontPath: '/fonts/',
                    className: 'icon'
                }))
                .pipe(gulp.dest(paths.sass));
        })
        .pipe(gulp.dest(paths.fonts));
});*/

gulp.task("modernizr", function () {
    //TODO:fetch modernizr-dev or build custom?
});

gulp.task("clean", function () {
    return del(paths.dist);
});

gulp.task("build", function (done) {
    runSequence("clean", ["jquery-js", "vendor-js", "modernizr", "sass", "js", "jade"], done);
});

gulp.task("watch", ["build"], function () {
    gulp.watch(paths.sass + "**/*.scss", ["sass"]);
    gulp.watch(paths.js + "**/*.js", ["js"]);
    gulp.watch(paths.jade + "**/*.*", ["jade"]);
});

gulp.task("test", ["watch"], function () {
    browserSync.init({
        server: {
            baseDir: ["./dist/", "./"]
        }
    });
});

gulp.task("default", ["build"]);

gulp.task("release", function() {
    optimize = true;
    runSequence("build", ["images", "css"]);
});
