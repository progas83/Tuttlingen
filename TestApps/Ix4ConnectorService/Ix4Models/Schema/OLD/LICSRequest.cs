﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.34014
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.0.30319.18020.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="http://logistikbroker.com/LICSRequest.xsd", IsNullable=false)]
public partial class LICSRequest {
    
    private int clientIdField;
    
    private LICSRequestArticle[] articleImportField;
    
    private LICSRequestOrder[] orderImportField;
    
    private LICSRequestDelivery[] deliveryImportField;
    
    private string versionField;
    
    public LICSRequest() {
        this.versionField = "1.02";
    }
    
    /// <remarks/>
    public int ClientId {
        get {
            return this.clientIdField;
        }
        set {
            this.clientIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Article", IsNullable=false)]
    public LICSRequestArticle[] ArticleImport {
        get {
            return this.articleImportField;
        }
        set {
            this.articleImportField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Order", IsNullable=false)]
    public LICSRequestOrder[] OrderImport {
        get {
            return this.orderImportField;
        }
        set {
            this.orderImportField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Delivery", IsNullable=false)]
    public LICSRequestDelivery[] DeliveryImport {
        get {
            return this.deliveryImportField;
        }
        set {
            this.deliveryImportField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    [System.ComponentModel.DefaultValueAttribute("1.02")]
    public string version {
        get {
            return this.versionField;
        }
        set {
            this.versionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestArticle {
    
    private int clientNoField;
    
    private bool clientNoFieldSpecified;
    
    private string articleNoField;
    
    private string articleNo2Field;
    
    private string articleDescriptionField;
    
    private string articleDescription2Field;
    
    private int identityNoField;
    
    private bool identityNoFieldSpecified;
    
    private string quantityUnitField;
    
    private string eANField;
    
    private string productCodeField;
    
    private string articleGroupField;
    
    private double articleGroupFactorField;
    
    private bool articleGroupFactorFieldSpecified;
    
    private double weightField;
    
    private bool weightFieldSpecified;
    
    /// <remarks/>
    public int ClientNo {
        get {
            return this.clientNoField;
        }
        set {
            this.clientNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ClientNoSpecified {
        get {
            return this.clientNoFieldSpecified;
        }
        set {
            this.clientNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ArticleNo {
        get {
            return this.articleNoField;
        }
        set {
            this.articleNoField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleNo2 {
        get {
            return this.articleNo2Field;
        }
        set {
            this.articleNo2Field = value;
        }
    }
    
    /// <remarks/>
    public string ArticleDescription {
        get {
            return this.articleDescriptionField;
        }
        set {
            this.articleDescriptionField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleDescription2 {
        get {
            return this.articleDescription2Field;
        }
        set {
            this.articleDescription2Field = value;
        }
    }
    
    /// <remarks/>
    public int IdentityNo {
        get {
            return this.identityNoField;
        }
        set {
            this.identityNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool IdentityNoSpecified {
        get {
            return this.identityNoFieldSpecified;
        }
        set {
            this.identityNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string QuantityUnit {
        get {
            return this.quantityUnitField;
        }
        set {
            this.quantityUnitField = value;
        }
    }
    
    /// <remarks/>
    public string EAN {
        get {
            return this.eANField;
        }
        set {
            this.eANField = value;
        }
    }
    
    /// <remarks/>
    public string ProductCode {
        get {
            return this.productCodeField;
        }
        set {
            this.productCodeField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleGroup {
        get {
            return this.articleGroupField;
        }
        set {
            this.articleGroupField = value;
        }
    }
    
    /// <remarks/>
    public double ArticleGroupFactor {
        get {
            return this.articleGroupFactorField;
        }
        set {
            this.articleGroupFactorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ArticleGroupFactorSpecified {
        get {
            return this.articleGroupFactorFieldSpecified;
        }
        set {
            this.articleGroupFactorFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double Weight {
        get {
            return this.weightField;
        }
        set {
            this.weightField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool WeightSpecified {
        get {
            return this.weightFieldSpecified;
        }
        set {
            this.weightFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestOrder {
    
    private string referenceNoField;
    
    private string orderNoField;
    
    private string extOrderNoField;
    
    private int clientNoField;
    
    private bool clientNoFieldSpecified;
    
    private int stateField;
    
    private bool stateFieldSpecified;
    
    private string customerOrderNoField;
    
    private string customerNoField;
    
    private string customerTextField;
    
    private int prioField;
    
    private bool prioFieldSpecified;
    
    private string deliveryTextField;
    
    private string shipmentTextField;
    
    private string packageTextField;
    
    private string commissionTextField;
    
    private string shippingTextField;
    
    private int shipmentModeField;
    
    private bool shipmentModeFieldSpecified;
    
    private System.DateTime shipmentDateField;
    
    private bool shipmentDateFieldSpecified;
    
    private System.DateTime createdDateField;
    
    private bool createdDateFieldSpecified;
    
    private double cashOnDeliveryAmountField;
    
    private bool cashOnDeliveryAmountFieldSpecified;
    
    private double orderAmountField;
    
    private bool orderAmountFieldSpecified;
    
    private string supplyAreaNoField;
    
    private string supplyPlaceNoField;
    
    private string stockOutAreaNoField;
    
    private string stockOutPlaceNoField;
    
    private string transportTypeField;
    
    private string distributionCenterField;
    
    private string paymentConditionField;
    
    private string commentField;
    
    private string currencyField;
    
    private LICSRequestOrderRecipient recipientField;
    
    private LICSRequestOrderPosition[] positionsField;
    
    /// <remarks/>
    public string ReferenceNo {
        get {
            return this.referenceNoField;
        }
        set {
            this.referenceNoField = value;
        }
    }
    
    /// <remarks/>
    public string OrderNo {
        get {
            return this.orderNoField;
        }
        set {
            this.orderNoField = value;
        }
    }
    
    /// <remarks/>
    public string ExtOrderNo {
        get {
            return this.extOrderNoField;
        }
        set {
            this.extOrderNoField = value;
        }
    }
    
    /// <remarks/>
    public int ClientNo {
        get {
            return this.clientNoField;
        }
        set {
            this.clientNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ClientNoSpecified {
        get {
            return this.clientNoFieldSpecified;
        }
        set {
            this.clientNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int State {
        get {
            return this.stateField;
        }
        set {
            this.stateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool StateSpecified {
        get {
            return this.stateFieldSpecified;
        }
        set {
            this.stateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string CustomerOrderNo {
        get {
            return this.customerOrderNoField;
        }
        set {
            this.customerOrderNoField = value;
        }
    }
    
    /// <remarks/>
    public string CustomerNo {
        get {
            return this.customerNoField;
        }
        set {
            this.customerNoField = value;
        }
    }
    
    /// <remarks/>
    public string CustomerText {
        get {
            return this.customerTextField;
        }
        set {
            this.customerTextField = value;
        }
    }
    
    /// <remarks/>
    public int Prio {
        get {
            return this.prioField;
        }
        set {
            this.prioField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PrioSpecified {
        get {
            return this.prioFieldSpecified;
        }
        set {
            this.prioFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string DeliveryText {
        get {
            return this.deliveryTextField;
        }
        set {
            this.deliveryTextField = value;
        }
    }
    
    /// <remarks/>
    public string ShipmentText {
        get {
            return this.shipmentTextField;
        }
        set {
            this.shipmentTextField = value;
        }
    }
    
    /// <remarks/>
    public string PackageText {
        get {
            return this.packageTextField;
        }
        set {
            this.packageTextField = value;
        }
    }
    
    /// <remarks/>
    public string CommissionText {
        get {
            return this.commissionTextField;
        }
        set {
            this.commissionTextField = value;
        }
    }
    
    /// <remarks/>
    public string ShippingText {
        get {
            return this.shippingTextField;
        }
        set {
            this.shippingTextField = value;
        }
    }
    
    /// <remarks/>
    public int ShipmentMode {
        get {
            return this.shipmentModeField;
        }
        set {
            this.shipmentModeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ShipmentModeSpecified {
        get {
            return this.shipmentModeFieldSpecified;
        }
        set {
            this.shipmentModeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime ShipmentDate {
        get {
            return this.shipmentDateField;
        }
        set {
            this.shipmentDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ShipmentDateSpecified {
        get {
            return this.shipmentDateFieldSpecified;
        }
        set {
            this.shipmentDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime CreatedDate {
        get {
            return this.createdDateField;
        }
        set {
            this.createdDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CreatedDateSpecified {
        get {
            return this.createdDateFieldSpecified;
        }
        set {
            this.createdDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double CashOnDeliveryAmount {
        get {
            return this.cashOnDeliveryAmountField;
        }
        set {
            this.cashOnDeliveryAmountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CashOnDeliveryAmountSpecified {
        get {
            return this.cashOnDeliveryAmountFieldSpecified;
        }
        set {
            this.cashOnDeliveryAmountFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double OrderAmount {
        get {
            return this.orderAmountField;
        }
        set {
            this.orderAmountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrderAmountSpecified {
        get {
            return this.orderAmountFieldSpecified;
        }
        set {
            this.orderAmountFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string SupplyAreaNo {
        get {
            return this.supplyAreaNoField;
        }
        set {
            this.supplyAreaNoField = value;
        }
    }
    
    /// <remarks/>
    public string SupplyPlaceNo {
        get {
            return this.supplyPlaceNoField;
        }
        set {
            this.supplyPlaceNoField = value;
        }
    }
    
    /// <remarks/>
    public string StockOutAreaNo {
        get {
            return this.stockOutAreaNoField;
        }
        set {
            this.stockOutAreaNoField = value;
        }
    }
    
    /// <remarks/>
    public string StockOutPlaceNo {
        get {
            return this.stockOutPlaceNoField;
        }
        set {
            this.stockOutPlaceNoField = value;
        }
    }
    
    /// <remarks/>
    public string TransportType {
        get {
            return this.transportTypeField;
        }
        set {
            this.transportTypeField = value;
        }
    }
    
    /// <remarks/>
    public string DistributionCenter {
        get {
            return this.distributionCenterField;
        }
        set {
            this.distributionCenterField = value;
        }
    }
    
    /// <remarks/>
    public string PaymentCondition {
        get {
            return this.paymentConditionField;
        }
        set {
            this.paymentConditionField = value;
        }
    }
    
    /// <remarks/>
    public string Comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    public string Currency {
        get {
            return this.currencyField;
        }
        set {
            this.currencyField = value;
        }
    }
    
    /// <remarks/>
    public LICSRequestOrderRecipient Recipient {
        get {
            return this.recipientField;
        }
        set {
            this.recipientField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Position", IsNullable=false)]
    public LICSRequestOrderPosition[] Positions {
        get {
            return this.positionsField;
        }
        set {
            this.positionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestOrderRecipient {
    
    private string firstNameField;
    
    private string nameField;
    
    private string additionalNameField;
    
    private string streetField;
    
    private string cityField;
    
    private string zIPCodeField;
    
    private string countryField;
    
    private string companyNameField;
    
    private string contactTitleField;
    
    private string contactTelephoneField;
    
    private string contactFaxField;
    
    private string contactEMailField;
    
    private string additionalTextField;
    
    /// <remarks/>
    public string FirstName {
        get {
            return this.firstNameField;
        }
        set {
            this.firstNameField = value;
        }
    }
    
    /// <remarks/>
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public string AdditionalName {
        get {
            return this.additionalNameField;
        }
        set {
            this.additionalNameField = value;
        }
    }
    
    /// <remarks/>
    public string Street {
        get {
            return this.streetField;
        }
        set {
            this.streetField = value;
        }
    }
    
    /// <remarks/>
    public string City {
        get {
            return this.cityField;
        }
        set {
            this.cityField = value;
        }
    }
    
    /// <remarks/>
    public string ZIPCode {
        get {
            return this.zIPCodeField;
        }
        set {
            this.zIPCodeField = value;
        }
    }
    
    /// <remarks/>
    public string Country {
        get {
            return this.countryField;
        }
        set {
            this.countryField = value;
        }
    }
    
    /// <remarks/>
    public string CompanyName {
        get {
            return this.companyNameField;
        }
        set {
            this.companyNameField = value;
        }
    }
    
    /// <remarks/>
    public string ContactTitle {
        get {
            return this.contactTitleField;
        }
        set {
            this.contactTitleField = value;
        }
    }
    
    /// <remarks/>
    public string ContactTelephone {
        get {
            return this.contactTelephoneField;
        }
        set {
            this.contactTelephoneField = value;
        }
    }
    
    /// <remarks/>
    public string ContactFax {
        get {
            return this.contactFaxField;
        }
        set {
            this.contactFaxField = value;
        }
    }
    
    /// <remarks/>
    public string ContactEMail {
        get {
            return this.contactEMailField;
        }
        set {
            this.contactEMailField = value;
        }
    }
    
    /// <remarks/>
    public string AdditionalText {
        get {
            return this.additionalTextField;
        }
        set {
            this.additionalTextField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestOrderPosition {
    
    private int positionNoField;
    
    private bool positionNoFieldSpecified;
    
    private string articleNoField;
    
    private string eANField;
    
    private string sSCCField;
    
    private string articleGroupField;
    
    private double targetQuantityField;
    
    private bool targetQuantityFieldSpecified;
    
    private string chargeField;
    
    private string serialNoField;
    
    private System.DateTime expiryDateField;
    
    private bool expiryDateFieldSpecified;
    
    private string projectNoField;
    
    private string customerTextField;
    
    private string commissionTextField;
    
    private string packageTextField;
    
    private string shipmentTextField;
    
    private string shippingTextField;
    
    private string commentField;
    
    private double netPriceField;
    
    private bool netPriceFieldSpecified;
    
    private double grossPriceField;
    
    private bool grossPriceFieldSpecified;
    
    private double taxField;
    
    private bool taxFieldSpecified;
    
    /// <remarks/>
    public int PositionNo {
        get {
            return this.positionNoField;
        }
        set {
            this.positionNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PositionNoSpecified {
        get {
            return this.positionNoFieldSpecified;
        }
        set {
            this.positionNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ArticleNo {
        get {
            return this.articleNoField;
        }
        set {
            this.articleNoField = value;
        }
    }
    
    /// <remarks/>
    public string EAN {
        get {
            return this.eANField;
        }
        set {
            this.eANField = value;
        }
    }
    
    /// <remarks/>
    public string SSCC {
        get {
            return this.sSCCField;
        }
        set {
            this.sSCCField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleGroup {
        get {
            return this.articleGroupField;
        }
        set {
            this.articleGroupField = value;
        }
    }
    
    /// <remarks/>
    public double TargetQuantity {
        get {
            return this.targetQuantityField;
        }
        set {
            this.targetQuantityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TargetQuantitySpecified {
        get {
            return this.targetQuantityFieldSpecified;
        }
        set {
            this.targetQuantityFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string Charge {
        get {
            return this.chargeField;
        }
        set {
            this.chargeField = value;
        }
    }
    
    /// <remarks/>
    public string SerialNo {
        get {
            return this.serialNoField;
        }
        set {
            this.serialNoField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime ExpiryDate {
        get {
            return this.expiryDateField;
        }
        set {
            this.expiryDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ExpiryDateSpecified {
        get {
            return this.expiryDateFieldSpecified;
        }
        set {
            this.expiryDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ProjectNo {
        get {
            return this.projectNoField;
        }
        set {
            this.projectNoField = value;
        }
    }
    
    /// <remarks/>
    public string CustomerText {
        get {
            return this.customerTextField;
        }
        set {
            this.customerTextField = value;
        }
    }
    
    /// <remarks/>
    public string CommissionText {
        get {
            return this.commissionTextField;
        }
        set {
            this.commissionTextField = value;
        }
    }
    
    /// <remarks/>
    public string PackageText {
        get {
            return this.packageTextField;
        }
        set {
            this.packageTextField = value;
        }
    }
    
    /// <remarks/>
    public string ShipmentText {
        get {
            return this.shipmentTextField;
        }
        set {
            this.shipmentTextField = value;
        }
    }
    
    /// <remarks/>
    public string ShippingText {
        get {
            return this.shippingTextField;
        }
        set {
            this.shippingTextField = value;
        }
    }
    
    /// <remarks/>
    public string Comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
    
    /// <remarks/>
    public double NetPrice {
        get {
            return this.netPriceField;
        }
        set {
            this.netPriceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool NetPriceSpecified {
        get {
            return this.netPriceFieldSpecified;
        }
        set {
            this.netPriceFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double GrossPrice {
        get {
            return this.grossPriceField;
        }
        set {
            this.grossPriceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool GrossPriceSpecified {
        get {
            return this.grossPriceFieldSpecified;
        }
        set {
            this.grossPriceFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double Tax {
        get {
            return this.taxField;
        }
        set {
            this.taxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TaxSpecified {
        get {
            return this.taxFieldSpecified;
        }
        set {
            this.taxFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestDelivery {
    
    private string deliveryNoField;
    
    private int clientNoField;
    
    private bool clientNoFieldSpecified;
    
    private System.DateTime deliveryDateField;
    
    private bool deliveryDateFieldSpecified;
    
    private string deliveryAreaField;
    
    private string deliveryPlaceField;
    
    private string referenceNoField;
    
    private System.DateTime orderDateField;
    
    private bool orderDateFieldSpecified;
    
    private LICSRequestDeliveryPosition[] positionsField;
    
    /// <remarks/>
    public string DeliveryNo {
        get {
            return this.deliveryNoField;
        }
        set {
            this.deliveryNoField = value;
        }
    }
    
    /// <remarks/>
    public int ClientNo {
        get {
            return this.clientNoField;
        }
        set {
            this.clientNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ClientNoSpecified {
        get {
            return this.clientNoFieldSpecified;
        }
        set {
            this.clientNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime DeliveryDate {
        get {
            return this.deliveryDateField;
        }
        set {
            this.deliveryDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool DeliveryDateSpecified {
        get {
            return this.deliveryDateFieldSpecified;
        }
        set {
            this.deliveryDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string DeliveryArea {
        get {
            return this.deliveryAreaField;
        }
        set {
            this.deliveryAreaField = value;
        }
    }
    
    /// <remarks/>
    public string DeliveryPlace {
        get {
            return this.deliveryPlaceField;
        }
        set {
            this.deliveryPlaceField = value;
        }
    }
    
    /// <remarks/>
    public string ReferenceNo {
        get {
            return this.referenceNoField;
        }
        set {
            this.referenceNoField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime OrderDate {
        get {
            return this.orderDateField;
        }
        set {
            this.orderDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool OrderDateSpecified {
        get {
            return this.orderDateFieldSpecified;
        }
        set {
            this.orderDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Position", IsNullable=false)]
    public LICSRequestDeliveryPosition[] Positions {
        get {
            return this.positionsField;
        }
        set {
            this.positionsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://logistikbroker.com/LICSRequest.xsd")]
public partial class LICSRequestDeliveryPosition {
    
    private int positionNoField;
    
    private bool positionNoFieldSpecified;
    
    private string referenceNoField;
    
    private string articleNoField;
    
    private string eANField;
    
    private string articleGroupField;
    
    private int loadTypeField;
    
    private bool loadTypeFieldSpecified;
    
    private int targetLoadsCountField;
    
    private bool targetLoadsCountFieldSpecified;
    
    private double articlePerLoadField;
    
    private bool articlePerLoadFieldSpecified;
    
    private double targetQuantityField;
    
    private string chargeField;
    
    private string serialNoField;
    
    private System.DateTime expiryDateField;
    
    private bool expiryDateFieldSpecified;
    
    private string projectNoField;
    
    private string sSCCField;
    
    private string commentField;
    
    /// <remarks/>
    public int PositionNo {
        get {
            return this.positionNoField;
        }
        set {
            this.positionNoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PositionNoSpecified {
        get {
            return this.positionNoFieldSpecified;
        }
        set {
            this.positionNoFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ReferenceNo {
        get {
            return this.referenceNoField;
        }
        set {
            this.referenceNoField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleNo {
        get {
            return this.articleNoField;
        }
        set {
            this.articleNoField = value;
        }
    }
    
    /// <remarks/>
    public string EAN {
        get {
            return this.eANField;
        }
        set {
            this.eANField = value;
        }
    }
    
    /// <remarks/>
    public string ArticleGroup {
        get {
            return this.articleGroupField;
        }
        set {
            this.articleGroupField = value;
        }
    }
    
    /// <remarks/>
    public int LoadType {
        get {
            return this.loadTypeField;
        }
        set {
            this.loadTypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LoadTypeSpecified {
        get {
            return this.loadTypeFieldSpecified;
        }
        set {
            this.loadTypeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public int TargetLoadsCount {
        get {
            return this.targetLoadsCountField;
        }
        set {
            this.targetLoadsCountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool TargetLoadsCountSpecified {
        get {
            return this.targetLoadsCountFieldSpecified;
        }
        set {
            this.targetLoadsCountFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double ArticlePerLoad {
        get {
            return this.articlePerLoadField;
        }
        set {
            this.articlePerLoadField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ArticlePerLoadSpecified {
        get {
            return this.articlePerLoadFieldSpecified;
        }
        set {
            this.articlePerLoadFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public double TargetQuantity {
        get {
            return this.targetQuantityField;
        }
        set {
            this.targetQuantityField = value;
        }
    }
    
    /// <remarks/>
    public string Charge {
        get {
            return this.chargeField;
        }
        set {
            this.chargeField = value;
        }
    }
    
    /// <remarks/>
    public string SerialNo {
        get {
            return this.serialNoField;
        }
        set {
            this.serialNoField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime ExpiryDate {
        get {
            return this.expiryDateField;
        }
        set {
            this.expiryDateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool ExpiryDateSpecified {
        get {
            return this.expiryDateFieldSpecified;
        }
        set {
            this.expiryDateFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public string ProjectNo {
        get {
            return this.projectNoField;
        }
        set {
            this.projectNoField = value;
        }
    }
    
    /// <remarks/>
    public string SSCC {
        get {
            return this.sSCCField;
        }
        set {
            this.sSCCField = value;
        }
    }
    
    /// <remarks/>
    public string Comment {
        get {
            return this.commentField;
        }
        set {
            this.commentField = value;
        }
    }
}
