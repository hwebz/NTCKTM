using System.IO;
using EPiServer;
using EPiServer.Core;
using EPiServer.Find.ClientConventions;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Find.Framework;
using EPiServer.Forms.Core;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Framework;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using KtmCompany.Web.Helpers;
using KtmCompany.Web.Models.BlockTypes;
using KtmCompany.Web.Models.MediaTypes;

namespace KtmCompany.Web.Initialization
{
    /// <summary>
    /// Credits: http://antecknat.se/blog/2015/02/23/convention-for-episerver-find-to-ignore-large-files/
    /// </summary>
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ContentInitialization : IInitializableModule
    {
        private static bool _initialized;

        public void Initialize(InitializationEngine context)
        {
            if (_initialized)
            {
                return;
            }

            var eventRegistry = ServiceLocator.Current.GetInstance<IContentEvents>();
            eventRegistry.CreatingContent += OnCreatingContent;

            IgnoreContentFromIndexing();

            _initialized = true;
        }       

        private static void OnCreatingContent(object sender, ContentEventArgs e)
        {
            var content = e.Content as MediaDataBase;

            if (content != null)
            {
                var path = ((FileBlob)content.BinaryData).FilePath;
                var length = new FileInfo(path).Length;

                content.FileSizeInKb = (int)(length / 1024);
            }
        }
        
        private void IgnoreContentFromIndexing()
        {
            //Ingnore EPiServer Form fields from Indexing            
            var searchClientConventions = SearchClient.Instance.Conventions;
            searchClientConventions.ForInstancesOf<FormContainerBlock>()
                .ExcludeField(x => x.Form)
                .ExcludeField(x => x.ElementsArea)
                .ExcludeField(x => x.Content);

            searchClientConventions.ForInstancesOf<ElementBlockBase>()
                .ExcludeField(x => x.FormElement)
                .ExcludeField(x => x.Content);

            ContentIndexer.Instance.Conventions.ForInstancesOf<MenuNavigationItemBlock>().ShouldIndex(x => false);
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            var eventRegistry = ServiceLocator.Current.GetInstance<IContentEvents>();
            eventRegistry.CreatingContent -= OnCreatingContent;
        }
    }
}