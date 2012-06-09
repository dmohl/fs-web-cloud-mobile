<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="HackySackStore" generation="1" functional="0" release="0" Id="b0537436-863f-4b95-855f-56813b1cf2bd" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="HackySackStoreGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="HackySackStoreFrontWebApi:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/HackySackStore/HackySackStoreGroup/LB:HackySackStoreFrontWebApi:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="HackySackStoreFrontWebApi:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApi:ServiceBusIssuer" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:ServiceBusIssuer" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApi:ServiceBusKey" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:ServiceBusKey" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApi:ServiceBusNamespace" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:ServiceBusNamespace" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApi:ServiceBusScheme" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:ServiceBusScheme" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApi:ServiceBusServicePath" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApi:ServiceBusServicePath" />
          </maps>
        </aCS>
        <aCS name="HackySackStoreFrontWebApiInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapHackySackStoreFrontWebApiInstances" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:ServiceBusIssuer" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:ServiceBusIssuer" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:ServiceBusKey" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:ServiceBusKey" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:ServiceBusNamespace" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:ServiceBusNamespace" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:ServiceBusScheme" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:ServiceBusScheme" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:ServiceBusServicePath" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:ServiceBusServicePath" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2:TableStorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2:TableStorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="OrderProcessor2Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderProcessor2Instances" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:HackySackStoreConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:HackySackStoreConnectionString" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:ServiceBusIssuer" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:ServiceBusIssuer" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:ServiceBusKey" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:ServiceBusKey" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:ServiceBusNamespace" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:ServiceBusNamespace" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:ServiceBusScheme" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:ServiceBusScheme" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStore:ServiceBusServicePath" defaultValue="">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStore:ServiceBusServicePath" />
          </maps>
        </aCS>
        <aCS name="OrderSQLStoreInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/HackySackStore/HackySackStoreGroup/MapOrderSQLStoreInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:HackySackStoreFrontWebApi:Endpoint1">
          <toPorts>
            <inPortMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapHackySackStoreFrontWebApi:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApi:ServiceBusIssuer" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/ServiceBusIssuer" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApi:ServiceBusKey" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/ServiceBusKey" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApi:ServiceBusNamespace" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/ServiceBusNamespace" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApi:ServiceBusScheme" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/ServiceBusScheme" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApi:ServiceBusServicePath" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi/ServiceBusServicePath" />
          </setting>
        </map>
        <map name="MapHackySackStoreFrontWebApiInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApiInstances" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:ServiceBusIssuer" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/ServiceBusIssuer" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:ServiceBusKey" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/ServiceBusKey" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:ServiceBusNamespace" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/ServiceBusNamespace" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:ServiceBusScheme" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/ServiceBusScheme" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:ServiceBusServicePath" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/ServiceBusServicePath" />
          </setting>
        </map>
        <map name="MapOrderProcessor2:TableStorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2/TableStorageConnectionString" />
          </setting>
        </map>
        <map name="MapOrderProcessor2Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2Instances" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:HackySackStoreConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/HackySackStoreConnectionString" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:ServiceBusIssuer" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/ServiceBusIssuer" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:ServiceBusKey" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/ServiceBusKey" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:ServiceBusNamespace" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/ServiceBusNamespace" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:ServiceBusScheme" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/ServiceBusScheme" />
          </setting>
        </map>
        <map name="MapOrderSQLStore:ServiceBusServicePath" kind="Identity">
          <setting>
            <aCSMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStore/ServiceBusServicePath" />
          </setting>
        </map>
        <map name="MapOrderSQLStoreInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStoreInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="HackySackStoreFrontWebApi" generation="1" functional="0" release="0" software="C:\git\fs-web-cloud-mobile\HackySackStore\HackySackStore\csx\Debug\roles\HackySackStoreFrontWebApi" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="ServiceBusIssuer" defaultValue="" />
              <aCS name="ServiceBusKey" defaultValue="" />
              <aCS name="ServiceBusNamespace" defaultValue="" />
              <aCS name="ServiceBusScheme" defaultValue="" />
              <aCS name="ServiceBusServicePath" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;HackySackStoreFrontWebApi&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HackySackStoreFrontWebApi&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;OrderProcessor2&quot; /&gt;&lt;r name=&quot;OrderSQLStore&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApiInstances" />
            <sCSPolicyFaultDomainMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApiFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="OrderProcessor2" generation="1" functional="0" release="0" software="C:\git\fs-web-cloud-mobile\HackySackStore\HackySackStore\csx\Debug\roles\OrderProcessor2" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="ServiceBusIssuer" defaultValue="" />
              <aCS name="ServiceBusKey" defaultValue="" />
              <aCS name="ServiceBusNamespace" defaultValue="" />
              <aCS name="ServiceBusScheme" defaultValue="" />
              <aCS name="ServiceBusServicePath" defaultValue="" />
              <aCS name="TableStorageConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;OrderProcessor2&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HackySackStoreFrontWebApi&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;OrderProcessor2&quot; /&gt;&lt;r name=&quot;OrderSQLStore&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2Instances" />
            <sCSPolicyFaultDomainMoniker name="/HackySackStore/HackySackStoreGroup/OrderProcessor2FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="OrderSQLStore" generation="1" functional="0" release="0" software="C:\git\fs-web-cloud-mobile\HackySackStore\HackySackStore\csx\Debug\roles\OrderSQLStore" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="HackySackStoreConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="ServiceBusIssuer" defaultValue="" />
              <aCS name="ServiceBusKey" defaultValue="" />
              <aCS name="ServiceBusNamespace" defaultValue="" />
              <aCS name="ServiceBusScheme" defaultValue="" />
              <aCS name="ServiceBusServicePath" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;OrderSQLStore&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;HackySackStoreFrontWebApi&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;OrderProcessor2&quot; /&gt;&lt;r name=&quot;OrderSQLStore&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStoreInstances" />
            <sCSPolicyFaultDomainMoniker name="/HackySackStore/HackySackStoreGroup/OrderSQLStoreFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="HackySackStoreFrontWebApiFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="OrderProcessor2FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="OrderSQLStoreFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="HackySackStoreFrontWebApiInstances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="OrderProcessor2Instances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="OrderSQLStoreInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="42d6da51-1ede-47be-9571-fa6b5e30359a" ref="Microsoft.RedDog.Contract\ServiceContract\HackySackStoreContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="35627750-dad4-418b-a1ed-9d02731443e7" ref="Microsoft.RedDog.Contract\Interface\HackySackStoreFrontWebApi:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/HackySackStore/HackySackStoreGroup/HackySackStoreFrontWebApi:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>