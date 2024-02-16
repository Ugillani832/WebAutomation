using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edible.PageObjects
{
    class OrderObjects
    {
        private IWebDriver driver;

        public OrderObjects(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        // [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")]
        // assigning above to variable Element
        // private IWebElement Element;

        [FindsBy(How = How.XPath, Using = "//input[@id='mui-1']")]
        //input[@id='mui-1']
        private IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//input[@role='combobox']")]
        private IWebElement SearchfieldFocus;

        //[FindsBy(How = How.XPath, Using = "//img[@class='imgArrThumb lazy']")] //a[@class='aArrImg']
        [FindsBy(How = How.XPath, Using = "//a[@oncontextmenu='changeURLWithBrowserBack(this);']")] 
        private IWebElement SearchedProduct;

        [FindsBy(How = How.XPath, Using = "//input[@data-test=\"pdp-pas-zip-input\"]")] 
        private IWebElement ZipCodeField;

        [FindsBy(How = How.XPath, Using = "//div[@name='ZIP_AVAILABILITY']//div[@role='radio']//div[2]")]
        private IWebElement DeliveryDate;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='pdp-pas-delivery-order-type']")]
        private IWebElement DeliveryOrder;

        [FindsBy(How = How.XPath, Using = "//div[@class='MuiBox-root css-1age63q']")]
        private IWebElement StoreSelect;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='pdp-upsells-top-continue-button']")]
        private IWebElement AddonContinue;

        [FindsBy(How = How.Name, Using = "firstName")]
        
        private IWebElement DelveryFirstNameField;

        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement DelveryLastNameField;

        [FindsBy(How = How.Name, Using = "address1")]
        private IWebElement DeliveryStreetAddressField;

        [FindsBy(How = How.XPath, Using = "//input[@data-test='pdp-recipient-form-home-phone']")]
        private IWebElement DelveryHomePhoneField;

        [FindsBy(How = How.XPath, Using = "//div[@id='recipient-information-address-type-select']")]
        private IWebElement Addresstypefield;

        [FindsBy(How = How.XPath, Using = "//div[@id='recipient-information-city-select']")]
        private IWebElement CityTownField;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Hamden']")]
        private IWebElement City;
        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Add To Cart']")]
        private IWebElement AddToCartButton;

        //[FindsBy(How = How.XPath, Using = "//div[@id='recipient-information-address-type-select']")]
        //private IWebElement AddressTypeField;
        //[FindsBy(How = How.XPath, Using = "//div[@id='recipient-information-address-type-select']")]
        //private IWebElement DelveryLastNameField;


        public IWebElement SearchProduct()
        {
            return SearchField;
        }
        public IWebElement SearchFieldFocustype()
        {
            return SearchfieldFocus;
        }
        public IWebElement GetSearchedProduct()
        {
            return SearchedProduct;
        }
        public IWebElement InsertZipCode() {
            return ZipCodeField;
        }
        public IWebElement DeliveryDateSelection() {
            return DeliveryDate;
        
        }
        public IWebElement DeliveryTypeOrder() {
            return DeliveryOrder;
        }

        public IWebElement StoreList()
        {
            return StoreSelect;
        }

        public IWebElement AddOnContinueButton()
        {
            return AddonContinue;
        }
        public IWebElement DeliveryFirstName()
        {
            return DelveryFirstNameField;
        }
        public IWebElement DeliveryLastName()
        {
            return DelveryLastNameField;
        }
        public IWebElement DeliveryStreetAddress()
        {
            return DeliveryStreetAddressField;
        }
        public IWebElement DeliveryHomePhone()
        {
            return DelveryHomePhoneField;
        }
        public IWebElement AddressType()
        {
            return Addresstypefield;
        }
        public IWebElement CityTown()
        {
            return CityTownField;
        }
        public IWebElement SelectCity()
        {
            return City;
        }
        public IWebElement AddToCart()
        {
            return AddToCartButton;
        }

       /* public IWebElement AddressType() {

            return AddressTypeField;
        }*/


    }
}
