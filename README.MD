
Sitecore Commerce Engine UPS Address Validation plugin (Sitecore Experience Commerce 9.1)
======================================

This plugin allows validating shipping address or billing address to make product delivery a good experience
- It is very easy to integrate or extend to fit your needs.



Sponsor
=======
This plugin was sponsored and created by Xcentium.

How to Install
==============

1. Copy it to your Sitecore Commerce Engine Solution and add it as a project 


2. Add it as a dependency to your Sitecore.Commerce.Engine project

3. Create a policy file named PlugIn.UpsAddressValidation.PolicySet-1.0.0.json under your Sitecore.Commerce.Engine/wwwroot/data/Environments  folder:


	So that the content section looks somewhat like below:

	Replace "xxxxx" with your UPS credentials.


```
{
  "$type": "Sitecore.Commerce.Core.PolicySet, Sitecore.Commerce.Core",
  "Id": "Entity-PolicySet-UpsAddressValidationPolicySet",
  "Version": 1,
  "IsPersisted": false,
  "Name": "UpsAddressValidationPolicySet",
  "Policies": {
    "$type": "System.Collections.Generic.List`1[[Sitecore.Commerce.Core.Policy, Sitecore.Commerce.Core]], mscorlib",
    "$values": [
      {
        "$type": "Sitecore.Commerce.Plugin.UpsAddressValidation.Policies.UpsAddressValidationPolicy, Sitecore.Commerce.Plugin.UpsAddressValidation",
        "UserName": "xxxxx",
        "Password": "xxxxx",
        "LicenseKey": "xxxxx",
        "ProdUrl": "xxxxx",
        "TestUrl": "xxxxx",
        "IsLive": false
      }
    ]
  }
}


```


Inside your corresponding json files for PlugIn.Habitat.CommerceAuthoring-1.0.0.json, PlugIn.Habitat.CommerceMinions-1.0.0.json and PlugIn.Habitat.CommerceShops-1.0.0.json
 you will need to add the line below. I added mine after braintree entry

 ```
       {
        "$type": "Sitecore.Commerce.Core.PolicySetPolicy, Sitecore.Commerce.Core",
        "PolicySetId": "Entity-PolicySet-UpsAddressValidationPolicySet"
      },


```
	You will need to bootstrap after adding all the above.

4. It is now ready to use. . 

Note:
=====

- If you have any questions, comment or need us to help install, extend or adapt to your needs, do not hesitate to reachout to us at XCentium.




