using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ICM.Web.Models
{
    public class Adjuster
    {
         public Adjuster()
        {
            this.CaseMVAs = new HashSet<CaseMVA>();
        }

         // Required – Indicates that the property is a required field
         //DisplayName – Defines the text we want used on form fields and validation messages
         //StringLength – Defines a maximum length for a string field
         //Range – Gives a maximum and minimum value for a numeric field
         //Bind – Lists fields to exclude or include when binding parameter or form values to model properties
         //ScaffoldColumn – Allows hiding fields from editor forms
         //        namespace MvcMusicStore.Models
         //{
         //    [Bind(Exclude = "AlbumId")]
         //    public class Album
         //    {
         //        [ScaffoldColumn(false)]
         //        public int      AlbumId    { get; set; }
         //        [DisplayName("Genre")]
         //        public int      GenreId    { get; set; }
         //        [DisplayName("Artist")]
         //        public int      ArtistId   { get; set; }
         //        [Required(ErrorMessage = "An Album Title is required")]
         //        [StringLength(160)]
         //        public string   Title      { get; set; }
         //        [Required(ErrorMessage = "Price is required")]
         //        [Range(0.01, 100.00,
         //            ErrorMessage = "Price must be between 0.01 and 100.00")]
         //        public decimal Price       { get; set; }
         //        [DisplayName("Album Art URL")]
         //        [StringLength(1024)]
         //        public string AlbumArtUrl { get; set; }
         //        public virtual Genre  Genre    { get; set; }
         //        public virtual Artist Artist   { get; set; }
         //    }
         //}



    
        [Key]
        public long AdjusterID { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Branch ID")]
        [Required]
        public long InsuranceCompanyBranchID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(50,ErrorMessage = "Maximum 50 characters")]
        public string FirstName { get; set; }


        [ScaffoldColumn(false)]
        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "Middle Name is Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string LastName { get; set; }


        [Display(Name = "Home Phone")]
        [Required(ErrorMessage = "Home Number Required")]
        [StringLength(15, ErrorMessage = "Maximum 15 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string Phone { get; set; }

        [Display(Name = "Ext.")]
        [Required(ErrorMessage = "Ext. is Required")]
        [StringLength(10, ErrorMessage = "Maximum 10 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string PhoneExtension { get; set; }


        [ScaffoldColumn(false)]
        [Display(Name = "Cell Phone")]
        [Required(ErrorMessage = "Cell Number Required")]
        [StringLength(50, ErrorMessage = "Mximum 50 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string CellPhone { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Other Number")]
        [Required(ErrorMessage = "Other Number Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string OtherPhone { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters")]
       
        [EmailAddress]
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Fax Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        [RegularExpression(@"[0-9 ]+", ErrorMessage = "Numbers only")]
        public string Fax { get; set; }


        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Code Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string Code { get; set; }


        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "By Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 characters")]
        public string By { get; set; }


        [ScaffoldColumn(false)]
        [Display(Name = "Updated")]
        [Required(ErrorMessage  = "Updated Required")]
        [DataType(DataType.Date)]
        public System.DateTime CreatedOrUpdated { get; set; }


        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Version Required")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numbers only")] 
        public int Version { get; set; }

        [Required(ErrorMessage = "Active Required")]
        public bool Active { get; set; }

        [ScaffoldColumn(false)]
        public virtual InsuranceCompanyBranch InsuranceCompanyBranch { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<CaseMVA> CaseMVAs { get; set; }
    }
}