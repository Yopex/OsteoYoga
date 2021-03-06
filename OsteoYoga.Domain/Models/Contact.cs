﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using OsteoYoga.Domain.Models.Interface;
using OsteoYoga.Resource;
using OsteoYoga.Resource.Contact;

namespace OsteoYoga.Domain.Models
{
    public abstract class Contact : Entity, IMailModel
    {
        protected Contact()
        {
            if (ConfirmedCode < 10000)
            {
                ConfirmedCode = new Random().Next(10000, 99999);
            }
        }

        [Required]
        public virtual string FullName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
        
        [Required]
        [RegularExpression("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$", ErrorMessageResourceType = typeof(LoginResource), ErrorMessageResourceName = "MailFormat")]
        public virtual string Mail { get; set; }

        [Required]
        [RegularExpression("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}", ErrorMessageResourceType = typeof(LoginResource), ErrorMessageResourceName = "PhoneFormat")]
        public virtual string Phone { get; set; }
        
        //todo à mettre en Enum
        public virtual string NetworkType { get; set; }
        public virtual string NetworkId { get; set; }
        public virtual IList<Profile> Profiles { get; set; }
        public virtual bool IsConfirmed { get; set; }
        public virtual int ConfirmedCode { get; set; }

        public override string ToString()
        {
            return FullName + " ( " + ModelResource.Mail + ": " + Mail + " ; " + ModelResource.Phone + ": " + Phone + " )";
        }

        public virtual bool IsValid()
        {
            Regex myRegex = new Regex("^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            if (Mail != null && Phone != null && FullName != null && myRegex.IsMatch(Mail))
            {
                return true;
            }
            return false;
        }
    }
}
