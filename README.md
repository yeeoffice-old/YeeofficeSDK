# YeeofficeSDK
Summary����SDK��Ҫ��װ�������б�Ľӿ�

����ʾ��


```
var context = AkmiiContext.GetAkmiiContext("��Ӧ������������ַ", "֪����Ϣ�䷢��token");
var response = context.Repository.SelectByListIDAsync(new CustomDataGetListRequest
{
    AppID = Ӧ��Id,
    ListID = �б�id
}).Result;
```