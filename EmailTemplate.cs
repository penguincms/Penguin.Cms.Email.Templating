using Penguin.Cms.Abstractions.Attributes;
using Penguin.Cms.Email.Abstractions.Extensions;
using Penguin.Cms.Email.Abstractions.Interfaces;
using Penguin.Cms.Entities;
using Penguin.Email.Abstractions.Interfaces;
using Penguin.Email.Templating.Abstractions.Interfaces;
using Penguin.Files.Abstractions;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System.Collections.Generic;

namespace Penguin.Cms.Email.Templating
{
    /// <summary>
    /// Represents a template used for generating email messages
    /// </summary>
    public class EmailTemplate : AuditableEntity, IPersistableEmailMessage, IEmailTemplate
    {
        /// <summary>
        /// The name of the handler that will generate the email
        /// </summary>
        [DontAllow(DisplayContexts.BatchEdit)]
        [Display(Order = -1000)]
        public string HandlerName { get; set; }

        public bool Enabled { get; set; } = true;

        public string From { get; set; }

        public string Subject { get; set; }

        public string Recipients { get; set; }

        public string CCRecipients { get; set; }

        public string BCCRecipients { get; set; }

        public bool IsHtml { get; set; }

        [DisplayType("System.String.Html")]
        [DontAllow(DisplayContexts.List)]
        public string Body { get; set; }

        public IEnumerable<IFile> Attachments { get; set; }

        IEnumerable<string> IEmailMessage.BCCRecipients => this.GetBCCRecipients();

        IEnumerable<string> IEmailMessage.CCRecipients => this.GetCCRecipients();

        IEnumerable<string> IEmailMessage.Recipients => this.GetRecipients();
    }
}