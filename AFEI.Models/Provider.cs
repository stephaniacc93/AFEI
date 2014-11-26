//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.Linq;

namespace AFEI.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Provider : IDataErrorInfo
    {
        public Provider()
        {
            this.Histories = new HashSet<History>();
            this.Products = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string error = "";
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Product> Products { get; set; }


        #region IDataErrorInfo Members

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrWhiteSpace(FirstName))
                        result = "Favor ingresar un nombre para el proveedor";
                }
                if (columnName == "LastName")
                {
                    if (string.IsNullOrWhiteSpace(LastName))
                        result = "Favor ingresar un apellido para el proveedor";
                }
                if (columnName == "Phone")
                {
                    if (string.IsNullOrEmpty(Phone))
                    {
                        result = "Favor ingresar un telefono para el cliente";
                    }
                    else
                    {
                        if (Phone.Count() >= 7)
                            result = "Favor ingresar un telefono valido";
                    }
                }
                if (columnName == "Company")
                {
                    if (string.IsNullOrWhiteSpace(Company))
                    {
                        result = "Favor ingresar una compania";
                    }
                }
                if (columnName == "Email")
                {
                    if (Email == null)
                    {
                        result = "Favor ingresar un correo electronico";
                    }
                    else
                    {
                        if (!Email.Contains("@"))
                        {
                            result = "Favor ingresar un correo electronico valido";
                        }
                    }
                }
                error = result;
                return result;
            }
        }

        #endregion
    }
}
