/*
 http://intercoolerjs.org/reference.html
 **/

using System.ComponentModel;

namespace Captions.RenderUtilities.RenderObjects
{
    public class Intercooler
    {
        [Description("ic-action")]
        public string action { get; set; }

        [Description("ic-action-target")]
        public string actiontarget { get; set; }

        [Description("ic-add-class")]
        public string addclass { get; set; }

        [Description("ic-append-from")]
        public string appendfrom { get; set; }

        [Description("ic-attr-src")]
        public string attrsrc { get; set; }

        [Description("ic-confirm")]
        public string confirm { get; set; }

        [Description("ic-delete-from")]
        public string deletefrom { get; set; }

        [Description("ic-deps")]
        public string deps { get; set; }

        [Description("ic-disable-when-doc-hidden")]
        public string disablewhendochidden { get; set; }

        [Description("ic-disable-when-doc-inactive")]
        public string disablewhendocinactive { get; set; }

        [Description("ic-fix-ids")]
        public string fixids { get; set; }

        [Description("ic-get-from")]
        public string getfrom { get; set; }

        [Description("ic-global-include")]
        public string globalinclude { get; set; }

        [Description("ic-history-elt")]
        public string historyelt { get; set; }

        [Description("ic-include")]
        public string include { get; set; }

        [Description("ic-indicator")]
        public string indicator => "#indicator";

        [Description("ic-limit-children")]
        public string limitchildren { get; set; }

        [Description("ic-local-vars")]
        public string localvars { get; set; }

        [Description("ic-on-beforeSend")]
        public string onbeforeSend { get; set; }

        [Description("ic-on-beforeTrigger")]
        public string onbeforeTrigger { get; set; }

        [Description("ic-on-complete")]
        public string oncomplete { get; set; }

        [Description("ic-on-error")]
        public string onerror { get; set; }

        [Description("ic-on-success")]
        public string onsuccess { get; set; }

        [Description("ic-patch-to")]
        public string patchto { get; set; }

        [Description("ic-pause-polling")]
        public string pausepolling { get; set; }

        [Description("ic-poll")]
        public string poll { get; set; }

        [Description("ic-poll-repeats")]
        public string pollrepeats { get; set; }

        [Description("ic-post-errors-to")]
        public string posterrorsto { get; set; }

        [Description("ic-post-to")]
        public string postto { get; set; }

        [Description("ic-prepend-from")]
        public string prependfrom { get; set; }

        [Description("ic-prompt")]
        public string prompt { get; set; }

        [Description("ic-push-url")]
        public string pushurl { get; set; }

        [Description("ic-put-to")]
        public string putto { get; set; }

        [Description("ic-remove-after")]
        public string removeafter { get; set; }

        [Description("ic-remove-class")]
        public string removeclass { get; set; }

        [Description("ic-replace-target")]
        public string replacetarget { get; set; }

        [Description("ic-scroll-offset")]
        public string scrolloffset { get; set; }

        [Description("ic-scroll-to-target")]
        public string scrolltotarget { get; set; }

        [Description("ic-select-from-response")]
        public string selectfromresponse { get; set; }

        [Description("ic-src")]
        public string src { get; set; }

        [Description("ic-sse-src")]
        public string ssesrc { get; set; }

        [Description("ic-style-src")]
        public string stylesrc { get; set; }

        [Description("ic-swap-style")]
        public string swapstyle { get; set; }

        [Description("ic-target")]
        public string target { get; set; }

        [Description("ic-transform-response")]
        public string transformresponse { get; set; }

        [Description("ic-transition-duration")]
        public string transitionduration { get; set; }

        [Description("ic-trigger-delay")]
        public string triggerdelay { get; set; }

        [Description("ic-trigger-from")]
        public string triggerfrom { get; set; }

        [Description("ic-trigger-on")]
        public string triggeron { get; set; }

        [Description("ic-verb")]
        public string verb { get; set; }


    }
}