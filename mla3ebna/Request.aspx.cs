using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mla3ebna_Request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Data()
    {
       
        /* To pass the merchant track id, in below sample merchant track id is hard-coded. Merchant
MUST pass his transaction ID (track ID) in this parameter. Track Id passed here should be 
from merchant backend system like database and not from customer browser
Merchant must ensure that each transaction has a unique Track ID. */
Random rnd = new Random(int.Parse(System.DateTime.Now.ToString()));  
String TranTrackid= String.valueOf(rnd.NextDouble());
       // String TranTrackid= String.valueOf(Math.abs(rnd.nextLong()));
String ReqTrackId="trackid="+TranTrackid+"&";
		
/* Getting Transaction Amount from previous pages. Since this sample page for demonstration, 
values from previous page is directly taken from browser and used for transaction processing.
Merchants SHOULD NOT follow this practice in production environment. */
String TranAmount=Request.QueryString["MAmount"];
String ReqAmount = "amt="+TranAmount+"&";

/* Tranportal ID is sensitive terminal information, merchant MUST ensure that Tranportal ID is never 
passed to customer browser by any means. Merchant MUST ensure that Tranportal ID is stored in a secure 
environment. Tranportal ID for test and production will be different, please contact PGSupport@knet.com.kw to
extract these details. */
String TranportalId = "";
String ReqTranportalId = "id="+ TranportalId +"&";
	
/* Tranportal password is sensitive terminal information, merchant MUST ensure that Tranportal password
is never passed to customer browser by any means. Merchant MUST ensure that Tranportal password is stored in a secure 
environment. Tranportal password for test and production will be different, please contact PGSupport@knet.com.kw to
extract these details. */
String TranportalPassword = "";
String ReqTranportalPassword = "password="+ TranportalPassword +"&";
	
/* Currency code of the transaction. this has to be set always to 414 (KD) */
String Currency = "414";
String ReqCurrency = "currencycode="+ Currency +"&";
	
/* Transaction language, this has to be set always to USA or AR */
String Langid = "USA";
String ReqLangid = "langid="+ Langid +"&";

/* Action Code of the transaction, this refers to type of transaction. 
Action Code 1 stands of Purchase transaction  */
String Action = "1";
String ReqAction = "action="+ Action +"&";

/* Response URL where Payment gateway will send response once transaction processing is completed 
Merchant MUST esure that below points in Response URL
1- Response URL must start with https://
2- the Response URL SHOULD NOT have any additional paramteres or query strings  */
String responseURL = "https://www.yourwebsite.com.kw/JSP/GetHandleRESponse.jsp";
String ReqResponseURL="responseURL="+ responseURL +"&";

/* Error URL where Payment gateway will send response in case any issues while processing the transaction 
Merchant MUST esure that below points in ErrorURL 
1- error url must start with https://
2- the error url SHOULD NOT have any additional paramteres or query strings */ 
String ErrorURL = "https://yourwebsite.com/JSP/result.jsp";
String ReqErrorURL = "errorURL="+ ErrorURL +"&";

/* User Defined Fields as per Merchant requirement. Merchant MUST ensure merchant is not passing junk values OR CRLF in any of the UDF. 
In below sample UDF values are not utilized */
String ReqUdf1 = "udf1="+"test1"+"&";	// UDF1 values
String ReqUdf2 = "udf2="+"test2"+"&";	// UDF2 value 
String ReqUdf3 = "udf3="+"test3"+"&";	// UDF3 value 
String ReqUdf4 = "udf4="+"test4"+"&";	// UDF4 value
String ReqUdf5 = "udf5="+"test5"+"&"; 	// UDF5 value

//==============================Encryption LOGIC CODE End==================================================================================================================================
/* Below are the fields / parameters which will be used for Encryption using (AES (128 bit)) Encryption 
   Algorithm. */

/* Terminal Resource Key is generated while creating terminal, And this the Key that is used for encrypting 
   the request/response from Merchant To PG and vice Versa
   Please contact PGSupport@knet.com.kw to extract this key */
String termResourceKey="";
String TranRequest=ReqAmount+ReqAction+ReqResponseURL+ReqErrorURL+ReqTrackId+ReqUdf1+ReqUdf2+ReqUdf3+ReqUdf4+ReqUdf5+ReqCurrency+ReqLangid+ReqTranportalId+ReqTranportalPassword;
	
String req="";
req = "&trandata="+encryptAES(TranRequest,termResourceKey)+"&errorURL="+errorURL+"&responseURL="+responseURL+"&tranportalId="+TranportalId;
	
//==============================Encryption LOGIC CODE End===================================================================================================================================
	
/* Log the complete request in the log file for future reference
Now creating a connection and sending request
Note - In JSP redirect function is used for redirecting request
*********UNCOMMENT THE BELOW REDIRECTION CODE TO CONNECT TO EITHER TEST OR PRODUCTION********* */
response.sendRedirect("https://kpaytest.com.kw/kpg/PaymentHTTP.htm?param=paymentInit"+req);
//response.sendRedirect("https://www.kpay.com.kw/kpg/PaymentHTTP.htm?param=paymentInit"+req);

%>
	
<%!
//AES Encryption Method Starts 
private static final String HEX_DIGITS = "0123456789abcdef";

public  String encryptAES(String encryptString,String key) throws Exception{		
byte[] encryptedText=null;
IvParameterSpec ivspec=null;
SecretKeySpec skeySpec=null;
Cipher cipher=null;
byte[]  text=null;
String s=null;
try{
System.out.println(""+encryptString);
ivspec = new IvParameterSpec(key.getBytes("UTF-8"));
skeySpec = new SecretKeySpec(key.getBytes("UTF-8"), "AES");
cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
cipher.init(Cipher.ENCRYPT_MODE, skeySpec,ivspec);
text = encryptString.getBytes("UTF-8");
encryptedText = cipher.doFinal(text);
s = byteArrayToHexString(encryptedText);
System.out.println(""+s);
}catch(Exception e){
e.printStackTrace();
}
finally
{
encryptedText=null;
ivspec=null;
skeySpec=null;
cipher=null; 
text=null;
}
return s.toUpperCase();		 
}

public static String byteArrayToHexString(byte[] data) {
return byteArrayToHexString(data, data.length);
}	
public static String byteArrayToHexString(byte[] data, int length) {
StringBuffer buf = new StringBuffer();

for (int i = 0; i != length; i++) {
int v = data[i] & 0xff;

buf.append(HEX_DIGITS.charAt(v >> 4));
buf.append(HEX_DIGITS.charAt(v & 0xf));
}

return buf.toString();
}
//AES Encryption Method Ends

    }
}