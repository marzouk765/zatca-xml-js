# مشروع إرسال رسائل واتساب - C# Windows Forms

هذا المشروع يوفّر واجهة بسيطة لإرسال رسائل واتساب نصّية عبر WhatsApp Cloud API الرسمي من Meta.

تحذير: لا يُنصح باستخدام أي حلول غير رسمية (أو أتمتة WhatsApp Web) لأنها مخالفة لشروط واتساب وقد تعرّض حسابك للإيقاف. استخدم API الرسمي فقط.

## المتطلبات
- نظام Windows 10/11
- .NET SDK 8 و/أو Visual Studio 2022 (مع دعم .NET 8)
- حساب WhatsApp Business على منصة Meta وإعداد WhatsApp Cloud API

## الإعداد عبر WhatsApp Cloud API
1. أنشئ تطبيقًا في منصة المطوّرين من Meta واربط WhatsApp: [وثائق WhatsApp Cloud API](https://developers.facebook.com/docs/whatsapp/cloud-api)
2. من صفحة "Getting Started" احصل على:
   - Access Token (ويفضّل إنشاء توكن طويل الأجل لاحقًا)
   - Phone Number ID
3. أضف رقمك إلى قائمة "Test numbers" أو استخدم رقم أعمال مفعل.
4. تأكد من قواعد الإرسال (نافذة الـ24 ساعة للرسائل غير القالبية، واستخدم قوالب معتمدة خارجها).

## التشغيل
1. افتح الحل في Visual Studio على Windows.
2. شغّل المشروع.
3. أدخل البيانات في الواجهة:
   - Access Token: التوكن الخاص بك
   - Phone Number ID: معرف رقم واتساب التجاري
   - Recipient (E.164): رقم المستلم بصيغة دولية بدون رموز، مثل 15551234567
   - Message: نص الرسالة
4. اضغط Send. ستظهر الاستجابة JSON في خانة Response.

## ملاحظات
- عنوان الإرسال:
  `https://graph.facebook.com/v20.0/{PHONE_NUMBER_ID}/messages`
- جسم الطلب (مثال نص بسيط):
  ```json
  {
    "messaging_product": "whatsapp",
    "to": "15551234567",
    "type": "text",
    "text": { "body": "Hello from WinForms!" }
  }
  ```
- تحتاج لضمان موافقة المستلم وفق سياسات واتساب، والالتزام بنافذة الرسائل.

بالتوفيق!