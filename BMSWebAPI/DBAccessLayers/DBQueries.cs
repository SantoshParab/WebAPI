using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMSWebAPI.DBAccessLayers
{
    public class DBQueries
    {
        #region santosh queries

        public static string InsertSamples = "INSERT INTO samplestransaction( Name, Age, Gender, MobileNumber, SRFID, LabId, KMIO, IsProcessed, IsUnderProcess, SampleReceiveDate, BulkNumber, PlateNumber, IsBlockedByPlate, PlateGenDate, HospitalId, Result, IsICMRProcessed, ImporterById, ProcessedById, ResultById, ModifiedById, ModifiedDateTime, ProcessedDateTime, ResultDateTime) VALUES"
            + " (@Name, @Age, @Gender, @MobileNumber, @SRFID, @LabId, @KMIO, @IsProcessed, @IsUnderProcess, Now(), @BulkNumber, @PlateNumber, @IsBlockedByPlate, Now(), @HospitalId, @Result, @IsICMRProcessed, @ImporterById, @ProcessedById, @ResultById, @ModifiedById, Now(), Now(), Now())";

        public static string InsertValidateTransaction = "INSERT INTO Validatetransaction( Name, Age, Gender, MobileNumber, SRFID, LabId, KMIO, IsProcessed, IsUnderProcess, SampleReceiveDate, BulkNumber, PlateNumber, IsBlockedByPlate, PlateGenDate, HospitalId, Result, IsICMRProcessed, ImporterById, ProcessedById, ResultById, ModifiedById, ModifiedDateTime, ProcessedDateTime, ResultDateTime) VALUES"
            + " (@Name, @Age, @Gender, @MobileNumber, @SRFID, @LabId, @KMIO, @IsProcessed, @IsUnderProcess, Now(), @BulkNumber, @PlateNumber, @IsBlockedByPlate, Now(), @HospitalId, @Result, @IsICMRProcessed, @ImporterById, @ProcessedById, @ResultById, @ModifiedById, Now(), Now(), Now())";

        public static string GetSamples = "SELECT `SampleId`, `Name`, `Age`, `Gender`, `MobileNumber`, `SRFID`, `LabId`, `KMIO`, "
            + "`IsProcessed`, `IsUnderProcess`, `SampleReceiveDate`, `BulkNumber`, `PlateNumber`, `IsBlockedByPlate`, "
            + "`PlateGenDate`, `HospitalId`, `Result`, `IsICMRProcessed`, `ImporterById`, `ProcessedById`, `ResultById`, "
            + "`ModifiedById`, `ModifiedDateTime`, `ProcessedDateTime`, `ResultDateTime` FROM `samplestransaction`";


        public static string InsertLabID = "INSERT INTO labid(hospitalid, Day, Month, Year, SerialNumber) VALUES (@hospitalid, @Day, @Month, @Year, @SerialNumber)";

        public static string CheckIfExistLabID = "select count(*)  from labid where hospitalid=@hospitalid and Day=@Day and Month=@Month and Year=@Year";

        public static string GetLabID = "select LPAD(SerialNumber,4,'0') from labid where hospitalid=@hospitalid and Day=@Day and Month=@Month and Year=@Year";

        public static string UpdateLabID = "Update labid set SerialNumber=@SerialNumber where hospitalid=@hospitalid and Day=@Day and Month=@Month and Year=@Year";

        //public static string GetBulkNumber = "select MAX(BulkNumber)+1 from bulktransaction";

        //public static string GetKMIONumber = "SELECT LPAD(MAX(KMIO)+1,7,'0') from samplestransaction";

        public static string GetBulkNumber = "select BulkNumber from bulknumber";

        public static string GetKMIONumber = "SELECT KMIONumber from kmio";

        public static string UpdateBulkNumber = "update bulknumber set bulknumber=@bulknumber";

        public static string UpdateKMIO = "update kmio set KMIONumber=@KMIONumber";

        public static string InsertKMIO = "INSERT INTO kmio(KMIONumber) VALUES(@KMIONumber)";

        public static string InsertBulkNumber = "INSERT INTO bulknumber(BulkNumber) VALUES(@bulknumber)";

        public static string InsertBulkTransaction = "INSERT INTO bulktransaction(BulkNumber, TotalTransaction, CompletedTransaction, Status, TransactionDate, ExcelLink, PdfLink) VALUES (@BulkNumber, @TotalTransaction, @CompletedTransaction, @Status, Now(), @ExcelLink, @PdfLink)";

        public static string dateformat1 = "%Y/%m/%d";
        public static string dateformat2 = "%d/%m/%Y";
        public static string GetBulkSamples = "select u.UserName,ut.UserType,s.bulknumber,date_format(s.SampleReceiveDate,@dateformat2) as importeddate,time(s.SampleReceiveDate) as importedtime,b.ExcelLink,b.PdfLink"
                                              + " from samplestransaction s"
                                              + " join bulktransaction b on s.BulkNumber=b.BulkNumber"
                                              + " join usersmaster u on s.ImporterById = u.UserId"
                                              + " join usertype ut on u.UserTypeId = ut.UserTypeId"
                                              + " where s.ImporterById= @userid  and  cast(s.SampleReceiveDate as date)  BETWEEN @fromdate and @todate"
                                              + " group by s.bulknumber,s.ImporterById "
                                              + " ORDER By s.SampleReceiveDate DESC limit @lowerlimit,@upperlimit";

        public static string GetBulkSamplesCount = "SELECT s.bulknumber FROM samplestransaction s"
                                                + " where s.ImporterById= @userid  and  cast(s.SampleReceiveDate as date)  BETWEEN @fromdate and @todate"
                                                + " group by s.bulknumber,s.ImporterById ";


        public static string GetSamplesforPlate = "select s.SampleId,s.BulkNumber,h.PHC,s.LabId,date_format(s.SampleReceiveDate,@dateformat2) as Date,s.IsProcessed from samplestransaction s"
                                                   + " JOIN hospitalmaster h on s.HospitalId=h.HospitalId"
                                                   + " where s.IsBlockedByPlate=0 and s.IsProcessed=1 and (cast(s.SampleReceiveDate as date) BETWEEN @fromdate and @todate "
                                                   + " or ((s.BulkNumber = @BulkNumber and s.HospitalId= @HospitalId) or(s.BulkNumber= @BulkNumber or s.HospitalId= @HospitalId)))"
                                                   + " ORDER by s.SampleReceiveDate DESC limit @lowerlimit,@upperlimit";

        public static string GetSamplesforPlateCount = "select count(*) from samplestransaction s"
                                                   + " where s.IsBlockedByPlate=0 and s.IsProcessed=1 and (cast(s.SampleReceiveDate as date) BETWEEN @fromdate and @todate "
                                                   + " or ((s.BulkNumber = @BulkNumber and s.HospitalId= @HospitalId) or(s.BulkNumber= @BulkNumber or s.HospitalId= @HospitalId)))";



        //public static string GetSamplesforPlate = "select s.SampleId,s.BulkNumber,h.PHC,s.LabId,date_format(s.SampleReceiveDate,@dateformat2) as Date,s.IsProcessed,s.IsUnderProcess from samplestransaction s JOIN hospitalmaster h on s.HospitalId=h.HospitalId where 1 = 1"
        //                                        + " and(s.SampleReceiveDate BETWEEN date_format(@fromdate,@dateformat1) and date_format(@fromdate,@dateformat1))"
        //                                        + " and(@BulkNumber IS Null or s.BulkNumber= @BulkNumber)"
        //                                        + " AND(@HospitalId IS Null or s.HospitalId= @HospitalId)"
        //                                        + " and s.IsBlockedByPlate=0 and s.IsProcessed= 1 ORDER by s.SampleReceiveDate";
        //                                        //+ " ORDER by s.SampleReceiveDate DESC limit @lowerlimit,@upperlimit";

        public static string AllotPlateNumber = "UPDATE samplestransaction set PlateNumber=@PlateNumber,ProcessedById=@ProcessedById,ModifiedById=@ModifiedById,PlateGenDate=Now(), SampleProcessedOrder=@SampleProcessedOrder, PoolNumber=@PoolNumber, PlateType=@PlateType where SampleId = @SampleId";

        public static string BlockSamples = "UPDATE samplestransaction set IsBlockedByPlate=1,ProcessedById=@ProcessedById,ModifiedById=@ModifiedById where SampleId = @SampleId";

        public static string DisAllotPlateNumber = "UPDATE samplestransaction set PlateNumber=0,IsBlockedByPlate=0,ProcessedById=@ProcessedById,ModifiedById=@ModifiedById where SampleId = @SampleId";

        public static string GetNextPlateNUmber = "SELECT plateno FROM platenumber where  Month=@Month and Year = @Year";

        public static string UpdatePlateNumber = "update platenumber set plateno=@plateno where Month=@Month and Year = @Year";

        public static string InsertPlateNumber = "INSERT INTO platenumber(PlateNo,Month,Year) VALUES (@PlateNo,@Month,@Year)";

        public static string GetPlateProcessedSamples = "SELECT u.UserName,PlateNumber,COUNT(SampleId) as noofsamples,date_format(PlateGenDate,@dateformat2) as date,time(SampleReceiveDate) as time"
                                                       + " from samplestransaction s"
                                                       + " JOIN usersmaster u on u.UserId = s.ProcessedById"
                                                       + " where s.ProcessedById= @ProcessedById and s.IsBlockedByPlate= 1 AND PlateNumber <> 0"
                                                       + " group by s.PlateNumber"
                                                       + " ORDER by s.PlateGenDate DESC limit @lowerlimit,@upperlimit";

        //public static string GetPlateProcessedSamplesCount = "SELECT COUNT(*) from samplestransaction s"
        //                                                    + " where s.ProcessedById= @ProcessedById and s.IsBlockedByPlate= 1"
        //                                                     + " group by s.PlateNumber";

        public static string GetPlateProcessedSamplesCount = "SELECT PlateNumber from samplestransaction s where s.ProcessedById= @ProcessedById and s.IsBlockedByPlate= 1 "
                              + " group by PlateNumber ";

        //public static string GetProccessedSamples = "SELECT PlateNumber,(select count(LabId) where result = 0) as PendingCount"
        //                                            + " from samplestransaction where PlateNumber!=0 "
        //                                            + " group by PlateNumber"
        //                                            +" limit @lowerlimit,@upperlimit";

        public static string GetProccessedSamples = " SELECT PlateNumber, ifnull((select count(LabId)),0) as PendingCount, PlateType"
                                                   + " from samplestransaction where result = 0 and PlateNumber!=0"
                                                   + " group by PlateNumber"
                                                   + " limit @lowerlimit,@upperlimit";

        public static string GetProccessedSamplesCount = "SELECT PlateNumber"
                                                    + " from samplestransaction where PlateNumber!=0 and result = 0"
                                                    + " group by PlateNumber";

        public static string GetProccessedSamplesPlatewise = "SELECT PlateNumber, ifnull((select count(LabId)),0) as PendingCount, PlateType"
                                                            + " from samplestransaction where result = 0 "
                                                            + " and PlateNumber = @PlateNumber"
                                                            + " group by PlateNumber";

        //public static string GetProccessedSamplesPlatewise = "SELECT PlateNumber,(select count(LabId) where result = 0) as PendingCount"
        //                                                    + " from samplestransaction"
        //                                                    + " where PlateNumber = @PlateNumber"
        //                                                    + " group by PlateNumber";




        //List All Labid for non admin users
        public static string GetAllLabIDforResult = "SELECT A.LabID,C.Result"
                                          + " from samplestransaction A, resultmaster C"
                                          + " Where A.Result = C.ResultID and A.Result = 0 and PlateNumber = @PlateNumber";
        //+ " limit @lowerlimit,@upperlimit";

        public static string GetAllLabIDforResultCount = "SELECT count(*)"
                                          + " from samplestransaction A, resultmaster C"
                                          + " Where A.Result = C.ResultID and A.Result = 0 and PlateNumber = @PlateNumber";

        //Get single LabID for non admin users
        public static string GetLabIDforResult = " SELECT A.LabID,C.Result"
                                        + " from samplestransaction A, resultmaster C"
                                        + " Where A.Result = C.ResultID and A.Result = 0 and A.LabID = @LabID and PlateNumber = @PlateNumber";

        //List All Labid for  admin users
        public static string GetAllLabIDforResultAdmin = "SELECT A.LabID,C.Result"
                                                         + " from samplestransaction A, resultmaster C"
                                                         + " Where A.Result = C.ResultID and PlateNumber = @PlateNumber Order By A.SampleProcessedOrder";
        //+ " limit @lowerlimit,@upperlimit";

        public static string GetAllLabIDforResultAdminCount = "SELECT count(*)"
                                                         + " from samplestransaction A, resultmaster C"
                                                         + " Where A.Result = C.ResultID and PlateNumber = @PlateNumber";
        //Get Labid for admin users
        public static string GetLabIDforResultAdmiin = "SELECT A.LabID,C.Result"
                                                        + " from samplestransaction A, resultmaster C"
                                                        + " Where A.Result = C.ResultID and A.LabID = @LabID and PlateNumber = @PlateNumber";


        public static string UpdateResult = "Update samplestransaction set Result = @Result,ResultById=@ResultById,ModifiedById=@ModifiedById,ResultDateTime=Now(),IsProcessed=2"
                                             + " where LabID = @LabID";

        public static string GetICMRData = "select date_format(A.Date,@dateformat2) as Date, A.Time, A.FileLink,(select count(B.LabId))  as TotalCount"
                                        + " from icmrreport A, samplestransaction B"
                                        + " where A.ReportId = B.ICMRReportId"
                                        + " and A.Date between @FromDate and @ToDate"
                                        + " Group by A.ReportId "
                                        + " limit @lowerlimit,@upperlimit";

        public static string GetICMRCount = "select A.Date"
                                            + " from icmrreport A,samplestransaction B"
                                            + " where  A.ReportId = B.ICMRReportId and A.Date between @FromDate and @ToDate"
                                            + " Group by A.ReportId ";

        public static string InsertICMR = "INSERT INTO icmrreport (Date,Time,FromDate,ToDate,CollectionDate,ReceivingDate,TestingDate,Kit,ICMRReportUser)"
                                            + " VALUES"
                                            + " (Date(now()),TIME(now()),@FromDate,@ToDate,@CollectionDate,@ReceivingDate,@TestingDate,@kit,@ICMRReportUser)";


        public static string UpdateICMRForSample = "update samplestransaction set ICMRReportId = @ReportId, IsICMRProcessed = 1"
                                                 + " where IsProcessed = 2 and IsICMRProcessed<>1 "
                                                 + " And cast(SampleReceiveDate as date) between @FromDate and @ToDate ";

        public static string GetICMRExcel = "select A.SRFID,concat('KMIO-COV-',A.KMIO) as PATIENTID ,A.SRFID as SAMPLEID ,"
            + " A.Name as PATIENT_NAME,date_format(@Collectiondate,@dateformat3) as COLLECTION_DATETIME,date_format(@Receivedate,@dateformat3) as RECEIVE_DATETIME,"
            + " date_format(@Testingdate,@dateformat3) as TESTING_DATETIME,'Nasopharyngeal & Oropharyngeal' as SAMPLE_TYPE,B.Result as FINAL_RESULT,"
            + " C.TestingKit as TESTING_KIT, B.Result as RDRp, '' as RDRp_CT,B.Result as EGENE,'' as EGENE_CT,B.Result as ORF1a,"
            + " '' as ORF1a_CT,'' as IsHospitalised,'' as IsRepeat,'' as Status,'' as StatusUpdate,concat('KMIO-COV-',A.KMIO) as Remarks,A.MobileNumber as MobileNumber"
            + " from samplestransaction A, resultmaster B,testingkit C"
            + " where A.Result= B.ResultId and C.TestingKitId=@TestingKit "
            + " And A.IsProcessed = 2 and A.IsICMRProcessed<>1"
            + " And cast(A.SampleReceiveDate as date) between @FromDate and @ToDate";

        public static string UpdateICMR = "update icmrreport set FileLink = @GeneratedFileLink where ReportId = @ReportId and ICMRReportUser = @ICMRReportUser";

        public static string GetreportID = "select max(ReportId),FromDate,ToDate from icmrreport where ICMRReportUser = @ICMRReportUser";

        public static string GetUserDetails = "SELECT u.UserId,u.UserName,u.Password,u.UserTypeId,u.IsActive,u.CreatedBy" +
                                        ",u.CreationDate,u.ModifiedBy,u.ModifiedDate,ut.UserType FROM usersmaster u join usertype ut on u.UserTypeId=ut.UserTypeId" +
                                        " WHERE Password=@Password and UserName=@UserName and u.IsActive=1";


        public static string InsertUser = "Insert into usersmaster (UserName, Password,UserTypeId,IsActive,CreatedBy,CreationDate)"
                                           + " Values(@username,@password, @usertypeid,1, @loggedinuserid, now())";

        public static string GetAllUsers = "SELECT A.UserId, A.UserName,A.Password, B.UserType, cast(A.CreationDate as Date) as CreationDate , A.IsActive"
                                            + " FROM usersmaster A, usertype B"
                                            + " where A.UserTypeId = B.UserTypeId"
                                            + " limit @lowerlimit,@upperlimit";

        public static string GetAllUsersCount = "SELECT count(*)"
                                            + " FROM usersmaster A, usertype B"
                                            + " where A.UserTypeId = B.UserTypeId";

        //public static string GetUser = "SELECT A.UserId, A.UserName,A.Password, B.UserType, cast(A.CreationDate as Date) as CreationDate , A.IsActive"
        //                                + " FROM usersmaster A, usertype B"
        //                                + " where A.UserTypeId = B.UserTypeId"
        //                                +" and A.UserName LIKE '%@username%'";

        public static string GetUser = "SELECT A.UserId, A.UserName,A.Password,"
                                        + " A.IsActive ,B.usertype,cast(A.CreationDate as Date) as CreatedDate"
                                        + " FROM usersmaster A join usertype B on A.UserTypeId = B.UserTypeId"
                                        + " where  A.UserName LIKE '%@username%'";

        public static string GetUserTypes = "Select  UserTypeId , UserType from usertype where IsActive = 1";

        public static string GetTestingKits = "SELECT TestingKitId,TestingKit,IsActive,cast(CreationDate as Date) as CreationDate FROM testingkit ";

        public static string GetTestingKits_N = "SELECT TestingKitId,TestingKit,IsActive,cast(CreationDate as Date) as CreationDate FROM testingkit  limit @lowerlimit, @upperlimit";

        public static string GetTestingKitCount = "SELECT count(*) FROM testingkit";

        public static string GetTestingKit = "SELECT TestingKitId,TestingKit, cast(CreationDate as Date) as CreationDate , IsActive"
                                            + " FROM testingkit"
                                            + " where TestingKit LIKE '%@kitname%'";

        public static string InsertTestingKit = "Insert into testingkit (TestingKit, IsActive,CreationDate)"
                                                + " Values(@kitname,1, now())";

        public static string UpdateTestingKit = "update testingkit set TestingKit = @kitname, IsActive=@IsActive"
                                                + " where TestingKitId = @TestingKitId;";

        public static string GetHospitals = "SELECT HospitalId, PHC, Code, Zone, Email, IsActive, cast(CreationDate as Date) as CreationDate, CreatedBy FROM hospitalmaster";

        public static string GetHospitals_N = "SELECT HospitalId, PHC, Code, Zone, Email, IsActive, cast(CreationDate as Date) as CreationDate, CreatedBy FROM hospitalmaster limit @lowerlimit, @upperlimit";

        public static string GetHospitalsCount = "SELECT count(*) FROM hospitalmaster  ";

        public static string GetHospital = "SELECT HospitalId, PHC, Code, Zone, Email, IsActive, CreationDate, CreatedBy FROM hospitalmaster where HospitalId=@HospitalId ";

        public static string GetPHC = "SELECT HospitalId,PHC,Code,Zone,Email,cast(CreationDate as Date) as CreationDate , IsActive"
                                    + " FROM hospitalmaster"
                                    + " where PHC LIKE '%@PHC%'";

        public static string InsertHospital = "Insert into hospitalmaster (PHC,Code,Zone,Email,IsActive,CreationDate)"
                                              + " Values(@PHC,@code,@zone,@email,1, now())";

        public static string UpdateHospital = "update hospitalmaster set PHC = @PHC,Code=@Code,Zone=@Zone,Email=@Email, IsActive=@IsActive"
                                               + " where HospitalId = @HospitalId";


        #endregion

        #region Nanddeep code

        public static string GetBulkReceivedReport = "select A.bulknumber,A.SampleReceiveDate as  ImportedDate, B.UserName, C.UserType,D.ExcelLink " +
       " From samplestransaction A,  usersmaster B, usertype C, bulktransaction D " +
       " Where A.ImporterById = B.UserId and B.UserTypeId = C.UserTypeId and A.bulknumber= D.BulkNumber " +
       " and cast(A.SampleReceiveDate as date) between @FromDate and @ToDate " +
       " group by A.bulknumber,cast(A.SampleReceiveDate as date) Order By A.bulknumber limit @lowerlimit, @upperlimit";

        public static string GetBulkReceivedReportCount = "select COUNT(distinct(A.bulknumber)) " +
       " From samplestransaction A,  usersmaster B, usertype C, bulktransaction D " +
       " Where A.ImporterById = B.UserId and B.UserTypeId = C.UserTypeId and A.bulknumber= D.BulkNumber " +
       " and cast(A.SampleReceiveDate as date) between @FromDate and @ToDate ";

        public static string GetBulkReport = "select cast(A.SampleReceiveDate as date)as ImportDate,A.BulkNumber,B.PHC, count(*) as TotalCount, "
                                                + " COUNT(CASE WHEN A.IsProcessed = 1 THEN 1 END) AS UnderProcessCount,"
                                                + " COUNT(CASE WHEN A.IsProcessed = 2 THEN 1 END) AS ProcessedCount,"
                                                + " COUNT(CASE WHEN A.Result = 1 THEN 1 END) AS PositiveCount,"
                                                + " COUNT(CASE WHEN A.Result = 2 THEN 1 END) AS NegativeCount,"
                                                + " COUNT(CASE WHEN A.Result = 3 THEN 1 END) AS RejectedCount"
                                                + " from samplestransaction A , hospitalmaster B"
                                                + " where A.HospitalId = B.HospitalID"
                                                + " and cast(A.SampleReceiveDate as date ) between @FromDate and @ToDate"
                                                + " and A.BulkNumber = @bulknumber"
                                                + " group by A.HospitalId, A.BulkNumber, cast(A.SampleReceiveDate as date) limit @lowerlimit, @upperlimit";


        public static string GetBulkReportCount = "select count(distinct (A.BulkNumber)) as TotalCount " +
        " from samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalID " +
        " and cast(A.SampleReceiveDate as date ) between @FromDate and @ToDate " +
        "  and A.BulkNumber = @bulknumber";

        public static string GetBulkReportwNull = "select cast(A.SampleReceiveDate as date)as ImportDate,A.BulkNumber,B.PHC, count(*) as TotalCount, " +
       " COUNT(CASE WHEN A.IsProcessed = 1 THEN 1 END) AS UnderProcessCount, " +
       " COUNT(CASE WHEN A.IsProcessed = 2 THEN 1 END) AS ProcessedCount, " +
       " COUNT(CASE WHEN A.Result = 1 THEN 1 END) AS PositiveCount, " +
       " COUNT(CASE WHEN A.Result = 2 THEN 1 END) AS NegativeCount, " +
       " COUNT(CASE WHEN A.Result = 3 THEN 1 END) AS RejectedCount " +
       " from samplestransaction A, hospitalmaster B " +
       " where A.HospitalId = B.HospitalID " +
       " and cast(A.SampleReceiveDate as date ) between @FromDate and @ToDate " +
       " group by A.HospitalId,A.BulkNumber,cast(A.SampleReceiveDate as date) limit @lowerlimit, @upperlimit";

        public static string GetBulkReportwNullCount = "select count(distinct (A.BulkNumber)) as TotalCount " +
        " from samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalID " +
        " and cast(A.SampleReceiveDate as date ) between @FromDate and @ToDate";

        public static string GetBulkReportPlus = "select cast(A.SampleReceiveDate as date)as ImportDate,A.BulkNumber,A.LabId, " +
        " (CASE " +
        " WHEN A.IsProcessed = 2 THEN 'Processed' " +
        " WHEN A.IsProcessed = 1 THEN 'Under Process' " +
        " ELSE 'Undefined' " +
        " END)Status2, " +
        " (CASE " +
        " WHEN A.Result = 1 THEN 'Positive' " +
        " WHEN A.Result = 2 THEN 'Negative' " +
        " WHEN A.Result = 3 THEN 'Rejected' " +
        " ELSE 'In Process' " +
        " END )Result " +
        " from samplestransaction A " +
        " where A.BulkNumber = @BulkNumber " +
        " and cast(A.SampleReceiveDate as date ) between @FromDate and @ToDate " +
        " and A.Result IN ( @Result ) " +
        " and A.IsProcessed IN ( @Status )";

        public static string GetSampleReceiveReport = "select cast(A.SampleReceiveDate as date)as ImportDate,A.Name,A.LabId,A.SRFID,A.Age,A.Gender, " +
        " B.PHC,A.BulkNumber, " +
        " (CASE " +
        " WHEN A.IsProcessed = 2 THEN 'Processed' " +
        " WHEN A.IsProcessed = 1 THEN 'Under Process' " +
        " ELSE 'Undefined' " +
        " END )Status2, " +
        " (CASE " +
        " WHEN A.Result = 1 THEN 'Positive' " +
        " WHEN A.Result = 2 THEN 'Negative' " +
        " WHEN A.Result = 3 THEN 'Rejected' " +
        " ELSE 'In Process' " +
        " END )Result " +
        " from samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalID " +
        " and cast(A.SampleReceiveDate as date) between @FromDate and @ToDate " +
        " and A.Result IN ( @Result ) " +
        " and A.IsProcessed IN ( @Status ) " +
        " and A.LabId = @LabId";

        public static string GetSampleReceiveReportwNull = "select cast(A.SampleReceiveDate as date)as ImportDate,A.Name,A.LabId,A.SRFID,A.Age,A.Gender, " +
        " B.PHC,A.BulkNumber, " +
        " (CASE " +
        " WHEN A.IsProcessed = 2 THEN 'Processed' " +
        " WHEN A.IsProcessed = 1 THEN 'Under Process' " +
        " ELSE 'Undefined' " +
        " END )Status2, " +
        " (CASE " +
        " WHEN A.Result = 1 THEN 'Positive' " +
        " WHEN A.Result = 2 THEN 'Negative' " +
        " WHEN A.Result = 3 THEN 'Rejected' " +
        " ELSE 'In Process' " +
        " END )Result " +
        " from samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalID " +
        " and cast(A.SampleReceiveDate as date) between @FromDate and @ToDate " +
        " and and A.Result IN ( @Result ) " +
        " and A.IsProcessed IN ( @Status )";

        public static string GetSampleReport = "select B.HospitalId, B.PHC, " +
        " (select count(A.LabId)) as TotalCount, " +
        " (select count(A.LabId) where A.IsProcessed = 1) as UnderProcessCount, " +
        " (select count(A.LabId) where A.IsProcessed = 2) as ProcessedCount, " +
        " (select count(A.LabId) where A.Result = 1) as PositiveCount, " +
        " (select count(A.LabId) where A.Result = 2) as NegativeCount, " +
        " (select count(A.LabId) where A.Result = 3) as RejectedCount " +
        " From samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalId " +
        " And cast(A.SampleReceiveDate as date) between @FromDate and @ToDate " +
        " And B.PHC IN ( @PHC ) " +
        " group by A.HospitalId";


        public static string GetSamplePlusReport = "select cast(A.SampleReceiveDate as date)ImportedDate,B.PHC,A.BulkNumber,A.LabId, " +
        " (CASE " +
        " WHEN A.IsProcessed = 2 THEN 'Processed' " +
        " WHEN A.IsProcessed = 1 THEN 'Under Process' " +
        " ELSE 'Undefined' " +
        " END)Status2, " +
        " (CASE " +
        " WHEN A.Result = 1 THEN 'Positive' " +
        " WHEN A.Result = 2 THEN 'Negative' " +
        " WHEN A.Result = 3 THEN 'Rejected' " +
        " ELSE 'In Process' " +
        " END )Result " +
        " From samplestransaction A, hospitalmaster B " +
        " where A.HospitalId = B.HospitalId and A.HospitalId = @HospitalID " +
        " and cast(A.SampleReceiveDate as date) between '@FromDate' and '@ToDate' " +
        " and A.Result IN ( @Result ) " +
        " and A.IsProcessed IN ( @Status )";

        #endregion


    }
}