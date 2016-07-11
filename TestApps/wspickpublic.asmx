<?xml version="1.0" encoding="utf-8"?>
<wsdl:definitions xmlns:s="http://www.w3.org/2001/XMLSchema" xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/" xmlns:tns="http://logistikbroker.com/ServiceLayer" xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/" xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" targetNamespace="http://logistikbroker.com/ServiceLayer" xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">
  <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">ix4 Public Interface for import or export data requests.</wsdl:documentation>
  <wsdl:types>
    <s:schema elementFormDefault="qualified" targetNamespace="http://logistikbroker.com/ServiceLayer">
      <s:element name="LICSImportXMLRequest">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="xmlFile" type="s:base64Binary" />
            <s:element minOccurs="0" maxOccurs="1" name="fileName" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LICSImportXMLRequestResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="LICSImportXMLRequestResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="LBSoapAuthenticationHeader" type="tns:LBSoapAuthenticationHeader" />
      <s:complexType name="LBSoapAuthenticationHeader">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="1" name="UserName" type="s:string" />
          <s:element minOccurs="0" maxOccurs="1" name="Password" type="s:string" />
          <s:element minOccurs="1" maxOccurs="1" name="ClientId" type="s:int" />
        </s:sequence>
        <s:anyAttribute />
      </s:complexType>
      <s:element name="ArticleImportCSVRequest">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="csvFile" type="s:base64Binary" />
            <s:element minOccurs="0" maxOccurs="1" name="fileName" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ArticleImportCSVRequestResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ArticleImportCSVRequestResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="OrderImportCSVRequest">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="csvFile" type="s:base64Binary" />
            <s:element minOccurs="0" maxOccurs="1" name="fileName" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="OrderImportCSVRequestResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="OrderImportCSVRequestResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DeliveryImportCSVRequest">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="csvFile" type="s:base64Binary" />
            <s:element minOccurs="0" maxOccurs="1" name="fileName" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="DeliveryImportCSVRequestResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="DeliveryImportCSVRequestResult" type="s:string" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:element name="ExportData">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="requestType" type="s:string" />
            <s:element minOccurs="0" maxOccurs="1" name="requestParameter" type="tns:ArrayOfString" />
          </s:sequence>
        </s:complexType>
      </s:element>
      <s:complexType name="ArrayOfString">
        <s:sequence>
          <s:element minOccurs="0" maxOccurs="unbounded" name="string" nillable="true" type="s:string" />
        </s:sequence>
      </s:complexType>
      <s:element name="ExportDataResponse">
        <s:complexType>
          <s:sequence>
            <s:element minOccurs="0" maxOccurs="1" name="ExportDataResult">
              <s:complexType mixed="true">
                <s:sequence>
                  <s:any />
                </s:sequence>
              </s:complexType>
            </s:element>
          </s:sequence>
        </s:complexType>
      </s:element>
    </s:schema>
  </wsdl:types>
  <wsdl:message name="LICSImportXMLRequestSoapIn">
    <wsdl:part name="parameters" element="tns:LICSImportXMLRequest" />
  </wsdl:message>
  <wsdl:message name="LICSImportXMLRequestSoapOut">
    <wsdl:part name="parameters" element="tns:LICSImportXMLRequestResponse" />
  </wsdl:message>
  <wsdl:message name="LICSImportXMLRequestLBSoapAuthenticationHeader">
    <wsdl:part name="LBSoapAuthenticationHeader" element="tns:LBSoapAuthenticationHeader" />
  </wsdl:message>
  <wsdl:message name="ArticleImportCSVRequestSoapIn">
    <wsdl:part name="parameters" element="tns:ArticleImportCSVRequest" />
  </wsdl:message>
  <wsdl:message name="ArticleImportCSVRequestSoapOut">
    <wsdl:part name="parameters" element="tns:ArticleImportCSVRequestResponse" />
  </wsdl:message>
  <wsdl:message name="ArticleImportCSVRequestLBSoapAuthenticationHeader">
    <wsdl:part name="LBSoapAuthenticationHeader" element="tns:LBSoapAuthenticationHeader" />
  </wsdl:message>
  <wsdl:message name="OrderImportCSVRequestSoapIn">
    <wsdl:part name="parameters" element="tns:OrderImportCSVRequest" />
  </wsdl:message>
  <wsdl:message name="OrderImportCSVRequestSoapOut">
    <wsdl:part name="parameters" element="tns:OrderImportCSVRequestResponse" />
  </wsdl:message>
  <wsdl:message name="OrderImportCSVRequestLBSoapAuthenticationHeader">
    <wsdl:part name="LBSoapAuthenticationHeader" element="tns:LBSoapAuthenticationHeader" />
  </wsdl:message>
  <wsdl:message name="DeliveryImportCSVRequestSoapIn">
    <wsdl:part name="parameters" element="tns:DeliveryImportCSVRequest" />
  </wsdl:message>
  <wsdl:message name="DeliveryImportCSVRequestSoapOut">
    <wsdl:part name="parameters" element="tns:DeliveryImportCSVRequestResponse" />
  </wsdl:message>
  <wsdl:message name="DeliveryImportCSVRequestLBSoapAuthenticationHeader">
    <wsdl:part name="LBSoapAuthenticationHeader" element="tns:LBSoapAuthenticationHeader" />
  </wsdl:message>
  <wsdl:message name="ExportDataSoapIn">
    <wsdl:part name="parameters" element="tns:ExportData" />
  </wsdl:message>
  <wsdl:message name="ExportDataSoapOut">
    <wsdl:part name="parameters" element="tns:ExportDataResponse" />
  </wsdl:message>
  <wsdl:message name="ExportDataLBSoapAuthenticationHeader">
    <wsdl:part name="LBSoapAuthenticationHeader" element="tns:LBSoapAuthenticationHeader" />
  </wsdl:message>
  <wsdl:portType name="LBAuthenticated">
    <wsdl:operation name="LICSImportXMLRequest">
      <wsdl:input message="tns:LICSImportXMLRequestSoapIn" />
      <wsdl:output message="tns:LICSImportXMLRequestSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ArticleImportCSVRequest">
      <wsdl:input message="tns:ArticleImportCSVRequestSoapIn" />
      <wsdl:output message="tns:ArticleImportCSVRequestSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="OrderImportCSVRequest">
      <wsdl:input message="tns:OrderImportCSVRequestSoapIn" />
      <wsdl:output message="tns:OrderImportCSVRequestSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="DeliveryImportCSVRequest">
      <wsdl:input message="tns:DeliveryImportCSVRequestSoapIn" />
      <wsdl:output message="tns:DeliveryImportCSVRequestSoapOut" />
    </wsdl:operation>
    <wsdl:operation name="ExportData">
      <wsdl:input message="tns:ExportDataSoapIn" />
      <wsdl:output message="tns:ExportDataSoapOut" />
    </wsdl:operation>
  </wsdl:portType>
  <wsdl:binding name="LBAuthenticated" type="tns:LBAuthenticated">
    <soap:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LICSImportXMLRequest">
      <soap:operation soapAction="http://logistikbroker.com/ServiceLayer/LICSImportXMLRequest" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
        <soap:header message="tns:LICSImportXMLRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ArticleImportCSVRequest">
      <soap:operation soapAction="http://logistikbroker.com/ServiceLayer/ArticleImportCSVRequest" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
        <soap:header message="tns:ArticleImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="OrderImportCSVRequest">
      <soap:operation soapAction="http://logistikbroker.com/ServiceLayer/OrderImportCSVRequest" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
        <soap:header message="tns:OrderImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DeliveryImportCSVRequest">
      <soap:operation soapAction="http://logistikbroker.com/ServiceLayer/DeliveryImportCSVRequest" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
        <soap:header message="tns:DeliveryImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExportData">
      <soap:operation soapAction="http://logistikbroker.com/ServiceLayer/ExportData" style="document" />
      <wsdl:input>
        <soap:body use="literal" />
        <soap:header message="tns:ExportDataLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:binding name="LBAuthenticated1" type="tns:LBAuthenticated">
    <soap12:binding transport="http://schemas.xmlsoap.org/soap/http" />
    <wsdl:operation name="LICSImportXMLRequest">
      <soap12:operation soapAction="http://logistikbroker.com/ServiceLayer/LICSImportXMLRequest" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
        <soap12:header message="tns:LICSImportXMLRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ArticleImportCSVRequest">
      <soap12:operation soapAction="http://logistikbroker.com/ServiceLayer/ArticleImportCSVRequest" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
        <soap12:header message="tns:ArticleImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="OrderImportCSVRequest">
      <soap12:operation soapAction="http://logistikbroker.com/ServiceLayer/OrderImportCSVRequest" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
        <soap12:header message="tns:OrderImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="DeliveryImportCSVRequest">
      <soap12:operation soapAction="http://logistikbroker.com/ServiceLayer/DeliveryImportCSVRequest" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
        <soap12:header message="tns:DeliveryImportCSVRequestLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
    <wsdl:operation name="ExportData">
      <soap12:operation soapAction="http://logistikbroker.com/ServiceLayer/ExportData" style="document" />
      <wsdl:input>
        <soap12:body use="literal" />
        <soap12:header message="tns:ExportDataLBSoapAuthenticationHeader" part="LBSoapAuthenticationHeader" use="literal" />
      </wsdl:input>
      <wsdl:output>
        <soap12:body use="literal" />
      </wsdl:output>
    </wsdl:operation>
  </wsdl:binding>
  <wsdl:service name="ix4PublicInterface">
    <wsdl:documentation xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/">ix4 Public Interface for import or export data requests.</wsdl:documentation>
    <wsdl:port name="LBAuthenticated" binding="tns:LBAuthenticated">
      <soap:address location="https://mackschuehle.logistic-cloud.com/system/webservices/wspickpublic.asmx" />
    </wsdl:port>
    <wsdl:port name="LBAuthenticated1" binding="tns:LBAuthenticated1">
      <soap12:address location="https://mackschuehle.logistic-cloud.com/system/webservices/wspickpublic.asmx" />
    </wsdl:port>
  </wsdl:service>
</wsdl:definitions>