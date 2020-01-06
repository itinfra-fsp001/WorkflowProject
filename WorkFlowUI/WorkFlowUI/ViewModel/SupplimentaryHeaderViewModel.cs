using BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace workWorkFlowUI.ViewModel
{
    public class SupplimentaryHeaderViewModel
    {
        public SupplimentaryHeaderViewModel()
        {
            // Your code here 
        }
        public List<tbl_CostObject> LtCostObject { get; set; }
        public tbl_SupBudgetHeader SupHeader { get; set; }
        // public SelectList CostObjects { get; set; }

        private List<SelectListItem> _costCentre;

        [Display(Name = "Raising Department")]
        public List<SelectListItem> CostCentre
        {
            get { return _costCentre; }
            set { _costCentre = value; }
        }


        private List<SelectListItem> _costObjects;

        [Display(Name = "Cost Objects")]
        public List<SelectListItem> CostObjects
        {
            get { return _costObjects; }
            set { _costObjects = value; }
        }

        private List<SelectListItem> _variationNumber;

        [Display(Name = "Variation Order No")]
        public List<SelectListItem> VariationNumbers
        {
            get { return _variationNumber; }
            set { _variationNumber = value; }
        }
        private List<SelectListItem> _objectNumbers;

        [Display(Name = "Object Numbers")]
        public List<SelectListItem> ObjectNumbers
        {
            get { return _objectNumbers; }
            set { _objectNumbers = value; }
        }

        //  public List<SelectListItem> ObjectNumbers { get; set; }
        [Display(Name = "Object Name")]
        public string ObjectName { get; set; }
        [Required(ErrorMessage = "Object No is required")]
        public string SelectedObjectNo { get; set; }
        [Required(ErrorMessage = "Cost Objects is required")]

        public string SelectedCostObject { get; set; }
        public string SelectedVarNo { get; set; }
        public IEnumerable<tbl_SupBudgetDetail> SupDetails { get; set; }

        [Required(ErrorMessage = "Raising Department is required")]
        public string SelectedCostCentre { get; set; }
        
        public tbl_SupBudgetDetail SupDetail { get; set; }

        


    }
}

