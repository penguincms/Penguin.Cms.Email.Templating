﻿using Penguin.Cms.Abstractions.Attributes;
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
        /// <inheritdoc/>
        public IEnumerable<IFile> Attachments { get; set; }

        /// <inheritdoc/>

        public string BCCRecipients { get; set; }

        IEnumerable<string> IEmailMessage.BCCRecipients => this.GetBCCRecipients();
        /// <inheritdoc/>

        [DisplayType("System.String.Html")]
        [DontAllow(DisplayContexts.List)]
        public string Body { get; set; }

        /// <inheritdoc/>

        public string CCRecipients { get; set; }

        IEnumerable<string> IEmailMessage.CCRecipients => this.GetCCRecipients();
        /// <inheritdoc/>

        public bool Enabled { get; set; } = true;
        /// <inheritdoc/>

        public string From { get; set; }

        /// <summary>
        /// The name of the handler that will generate the email
        /// </summary>
        [DontAllow(DisplayContexts.BatchEdit)]
        [Display(Order = -1000)]
        public string HandlerName { get; set; }

        /// <inheritdoc/>

        public bool IsHtml { get; set; }

        /// <inheritdoc/>
        public string Recipients { get; set; }

        IEnumerable<string> IEmailMessage.Recipients => this.GetRecipients();

        /// <inheritdoc/>
        public string Subject { get; set; }
    }
}