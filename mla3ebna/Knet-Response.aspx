<%@ Page Language="C#"   %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <%
         
            String ResPaymentId, ResResult, ResErrorText, ResPosdate, ResTranId, ResAuth, ResAmount, ResErrorNo, ResTrackID, ResRef, ResAVR, Resudf1, Resudf2, Resudf3, Resudf4, Resudf5, trandata;
            ResErrorText = Request.Form["ErrorText"];	//Error Text/message
            ResErrorNo = Request.Form["Error"];			//Error Number					
            ResPaymentId = Request.Form["paymentid"];	//Payment Id
            ResTrackID = Request.Form["trackid"];		//Merchant Track ID
            ResResult = Request.Form["result"];			//Transaction Result
            ResPosdate = Request.Form["postdate"];		//Postdate					
            ResTranId = Request.Form["tranid"];			//Transaction ID
            ResAuth = Request.Form["auth"];				//Auth Code		
            ResAVR = Request.Form["avr"];				//TRANSACTION avr
            ResRef = Request.Form["ref"];				//Reference Number also called Seq Number					
            ResAmount = Request.Form["amt"];				//Transaction Amount
            Resudf1 = Request.Form["udf1"];				//UDF1
            Resudf2 = Request.Form["udf2"];				//UDF2
            Resudf3 = Request.Form["udf3"];				//UDF3
            Resudf4 = Request.Form["udf4"];				//UDF4
            Resudf5 = Request.Form["udf5"];				//UDF5

          
            String termResourceKey = "";

            trandata = Request.Form["trandata"];

            
            if (ResErrorText == null && ResErrorNo == null && trandata != null)
            {

                //Decryption logice starts
                //trandata = decryptAES(trandata, termResourceKey];

                /* IMPORTANT NOTE - MERCHANT SHOULD UPDATE TRANACTION PAYMENT STATUS IN HIS DATABASE AT THIS POINT 
                AND THEN REDIRECT CUSTOMER TO THE RESULT PAGE. */
                string ls = "PaymentID=" + ResPaymentId + "&Result=" + ResResult + "&PostDate=" + ResPosdate + "&TranID=" + ResTranId + "&Ref=" + ResRef + "&TrackID=" + ResTrackID + "&Auth=" + ResAuth + "&amount=" + ResAmount + "&trandata=" + trandata;
                Response.Redirect("https://www.youth.gov.kw/mla3ebna/Sucess.aspx?trandata=" + trandata);
            }
            else
            {
               // Response.Redirect("https://www.youth.gov.kw/mla3ebna/Fail.aspx?Error=" + ResErrorNo + "&ErrorText=" + ResErrorText + "&TrackID=" + ResTrackID + "&amt=" + ResAmount + "&paymentid=" + ResPaymentId + "&TranID=" + ResTranId + "&Result=" + ResResult + "&udf1=" + Resudf1 + "&udf2=" + Resudf2 + "&udf3=" + Resudf3 + "&udf4=" + Resudf4 + "&udf5=" + Resudf5);
                Response.Redirect("https://www.youth.gov.kw/mla3ebna/Fail.aspx?trandata=" + trandata);
            }

            
            
            
        %>


    
    </div>
    </form>
</body>
</html>
