// From DOM element, get the FormDescriptor object
function getFormDescriptor($workingForm) {
    var workingFormGuid = epi.EPiServer.Forms.Utils.getFormIdentifier($workingForm),
        workingFormInfo = epi.EPiServer.Forms[workingFormGuid];

    workingFormInfo.$workingForm = $workingForm;

    return workingFormInfo;
}

function formElementValueChanged(element) {
    validateElement(element, getFormDescriptor($(element).closest(".EPiServerForms")));
}

function validateDateInDDMMYYYYFormat(dateFieldContainer) {
    var splitFields = dateFieldContainer.find('.FormTextbox__Input').val().split('/');
    var valid = true;
    if (splitFields.length == 3) {
        var day = parseInt(splitFields[0]);
        var month = parseInt(splitFields[1]);
        var year = parseInt(splitFields[2]);
        if (isNaN(day) || isNaN(month) || isNaN(year)) {
            valid = false;
        } else {
            // Create list of days of a month [assume there is no leap year by default]
            var listOfDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            if (month == 1 || month > 2) {
                if (day > listOfDays[month - 1]) {
                    valid = false;
                }
            }
            if (month == 2) {
                var lyear = false;
                if ((!(year % 4) && year % 100) || !(year % 400)) {
                    lyear = true;
                }
                if ((lyear == false) && (day >= 29)) {
                    valid = false;
                }
                if ((lyear == true) && (day > 29)) {
                    valid = false;
                }
            }
        }
    } else {
        valid = false;
    }
    var errorContainer = dateFieldContainer.find('.Form__Element__ValidationError');
    var dateSelectionContainer = dateFieldContainer.find('.CustomDateSelectionContainer');
    if (!valid) {
        errorContainer.html("Enter a date in the DD/MM/YYYY format.").show();
        //dateSelectionContainer.addClass('error');
    } else {
        errorContainer.html("").hide();
        //dateSelectionContainer.removeClass('error');
    }
    return valid;
}

function getElementValidators(/*Array*/formValidationInfo, /*String*/elementIdentifier) {
    if (!(formValidationInfo instanceof Array) || formValidationInfo.length === 0 || !elementIdentifier) {
        return;
    }

    var itemIndex = 0,
        totalItems = formValidationInfo.length,
        item = null;
    for (; itemIndex < totalItems; itemIndex++) {
        item = formValidationInfo[itemIndex];
        if (!item) {
            continue;
        }

        if (item.targetElementId === elementIdentifier || item.targetElementName === elementIdentifier) {
            return item.validators;
        }
    }
}
// summary: Validate a field with input value.
// return: Array of result object. ex [ { isValid: true }]
function validateFormValue(fieldName, fieldValue, validators) {
    var results = [];

    $(validators).each(function (index, item) {

        // take the Actor, it can be function to execute, or contain property (of type function) "validate"
        var validatorActor = epi.EPiServer.Forms.Validators[item.type];
        var validatorFunc = null;

        if (typeof validatorActor === "function") {
            validatorFunc = validatorActor;
        } else if (typeof validatorActor["validate"] === "function") {
            validatorFunc = validatorActor["validate"];
        }

        // execute the validatorFunc
        if (validatorFunc) {
            var itemResult = validatorFunc(fieldName, fieldValue, item);
            $.extend(itemResult, { fieldName: fieldName, fieldValue: fieldValue });
            results.push(itemResult);
        }
    });

    return results;
}

function getValidationMessage(/*Object*/$element) {
    // summary:
    //      Gets message container object by the given element
    // $element: [Object]
    //      Current element as jQuery object
    // returns: [Object]
    //      Message container as jQuery object
    // tags:
    //      private

    // try to find Form__Element__ValidationError based on name attribute first
    var elementName = $element.attr('name') || $element.data('epiforms-element-name');
    var selector = epi.EPiServer.Forms.Utils.stringFormat("{0}[data-epiforms-linked-name='{1}'], {0}[data-epiforms-linked-name='{2}']",
        [".Form__Element__ValidationError", elementName, $element.attr('id')]);
    return selector;
}

// element: should be the DOM root of each Form__Element
function validateElement(element, workingFormInfo) {
    var $element = $(element),
        elementName = $element.attr("name") || $element.data("epiforms-element-name"),
        messageContainer = getValidationMessage($element),
        elementIdentifier = $element.attr("id") || elementName,
        validators = getElementValidators(workingFormInfo.ValidationInfo, elementIdentifier),
        isValid = true;

    var $messageContainer = $(messageContainer);

    if (!(validators instanceof Array) || validators.length === 0) {
        return isValid;
    }

    var elementValue = epi.EPiServer.Forms.Utils.getElementValue($element);
    var results = validateFormValue(elementName, elementValue, validators);
    var invalidResultItems = $.grep(results, function (item) {
        return item.isValid == false;
    });
    var inputElement = $element.find("input, select");
    if ($element.hasClass("CustomChoiceElementBlock")) {
        inputElement = $element.find('.CustomChoiceElementContainer');
    }  else if ($element.hasClass("CustomCheckboxBlock")) {
        inputElement = $element.find('.CustomCheckboxContainer');
    } else if ($element.hasClass("CustomDateSelectionBlock")) {
        inputElement = $element.find('.CustomDateSelectionContainer');
    }
    if (invalidResultItems && invalidResultItems.length > 0) {
        var messages = $.map(invalidResultItems, function (item) {
            return item.message;
        });

        $element.addClass("ValidationFail");
        inputElement.removeClass("valid");
        if (!$element.hasClass("CustomChoiceElementBlock") && !$element.hasClass("CustomCheckboxBlock") && !$element.hasClass("CustomDateSelectionBlock")) {
            inputElement.addClass("error");
        }
        $messageContainer.text(messages.join(" ")).show();

        return false;
    } else {        
        if ($element.hasClass("CustomDateSelectionBlock")) {
            return validateDateInDDMMYYYYFormat($element);
        } else {
            $element.removeClass("ValidationFail");
            inputElement.removeClass("error");
            if (!$element.hasClass("CustomChoiceElementBlock") && !$element.hasClass("CustomCheckboxBlock") && !$element.hasClass("CustomDateSelectionBlock")) {
                inputElement.addClass("valid");
            }
            $messageContainer.hide();

            return true;
        }
    }
}
$(function () {
    'use strict';
    if (typeof (epi) == 'undefined' || typeof (epi.EPiServer) == 'undefined' || typeof (epi.EPiServer.Forms) == 'undefined') {
        console.error('Forms is not initialized correctly');
        return {};
    }
    if (typeof ($) == 'undefined') {
        console.error('Forms cannot work without jQuery');
        return {};
    }
    if (!window.$$epiforms) {
        console.log('custom-form-validation: cannot find $$epiforms');
        return {};
    }
    
   
    return {        
        _init: function () {            
            this._initForm();
        },

        _initForm: function () {
            $$epiforms('.EPiServerForms').on('formsStepValidating', this.onFormStepValidating.bind(this));
        },

        onFormStepValidating: function (e) {
            var isValid = true;
            var $workingFormInfo = e.workingFormInfo;
            $workingFormInfo.$steps.each(function (i, $container) {
                $(".FormTextbox, .FormTextbox--Textarea, .FormSelection, .FormChoice, .FormFileUpload, .Form__CustomElement", $container).each(function (index, element) {
                    var temp = validateElement(element, $workingFormInfo);
                    isValid = isValid && temp;                    
                });
            });            
        }

    }._init();
});
