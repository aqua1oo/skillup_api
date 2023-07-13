using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ApiClientHelper
{
    #region API
    public class ApiCommonConstant
    {
        /**
         * API 연동 정보
         * URL_API_DEV : 연동 개발 서버
         * URL_API_REAL : 연동 실서버 서버
         * */
        public const string URL_API_DEV = "http://d-eai.kyowon.co.kr:10001";
        public const string URL_API_REAL = "http://eai.kyowon.co.kr:10001";        

        /**
         * WELLS QR 연동 정보 API 정보         
         * */
        public static readonly Hashtable HASH_URL_API = new Hashtable()
        {
            //인터페이스 ID로 정리
            //EAI_CBDI0001 : EAI 테스트
            {"EAI_CBDI0001", "/mediate/KYOWON/C/BD/EAI_CBDI0001/req"},   
            
            //EAI_ECLI1004 : 플랜마일리지-교원에듀조회
            {"EAI_ECLI1004", "/mediate/KYOWON/E/CL/EAI_ECLI1004/req"},
            //EAI_ECLI1005 : 플랜마일리지-교원에듀상세조회
            {"EAI_ECLI1005", "/mediate/KYOWON/E/CL/EAI_ECLI1005/req"},
            //EAI_ECLI1006 : 플랜마일리지-체험상세
            {"EAI_ECLI1006", "/mediate/KYOWON/E/CL/EAI_ECLI1006/req"},
            //EAI_ECLI1013 : 플랜마일리지-체험조회
            {"EAI_ECLI1013", "/mediate/KYOWON/E/CL/EAI_ECLI1013/req"},

            //EAI_ECUI1004 : 에듀-상담신청 교원키조회
            {"EAI_ECUI1004", "/mediate/KYOWON/E/CU/EAI_ECUI1004/req"},
            //EAI_ECUI1005 : 에듀-진단검사 쿠폰 유효성 체크
            {"EAI_ECUI1005", "/mediate/KYOWON/E/CU/EAI_ECUI1005/req"},
            //EAI_ECUI1006 : 에듀-진단검사 쿠폰 완료처리
            {"EAI_ECUI1006", "/mediate/KYOWON/E/CU/EAI_ECUI1006/req"},
            //EAI_ECUI1008 : 에듀-통합 멤버십 무료체험 신청가능여부
            {"EAI_ECUI1008", "/mediate/KYOWON/E/CU/EAI_ECUI1008/req"},
            //EAI_ECUI1010 : 에듀-상담신청 교원키 순번조회
            {"EAI_ECUI1010", "/mediate/KYOWON/E/CU/EAI_ECUI1012/req"},
            //EAI_ECUI1011 : 에듀-신한제휴_신규고객가입
            {"EAI_ECUI1011", "/mediate/KYOWON/E/CU/EAI_ECUI1011/req"},
            //EAI_ECUI1014 : 에듀-K-컨설팅 쿠폰 유효성 체크
            {"EAI_ECUI1014", "/mediate/KYOWON/E/CU/EAI_ECUI1011/req"},
            //EAI_ECUI1017 : 에듀-K-컨설팅 프리테스트 쿠폰생성
            {"EAI_ECUI1017", "/mediate/KYOWON/E/CU/EAI_ECUI1017/req"},
            //EAI_ECUI1018 : 에듀-Y-컨설팅 쿠폰 유효성 체크
            {"EAI_ECUI1018", "/mediate/KYOWON/E/CU/EAI_ECUI1018/req"},
            //EAI_WCLI1012 : 에듀-총보유K머니조회
            {"EAI_WCLI1012", "/mediate/KYOWON/E/CU/EAI_ECUI1018/req"},
            //EAI_WCLI1013 : 에듀-K머니사용내역조회
            {"EAI_WCLI1013", "/mediate/KYOWON/W/CL/EAI_WCLI1013/req"},
            //EAI_WCLI1014 : 에듀-K머니사용내역조회
            {"EAI_WCLI1014", "/mediate/KYOWON/W/CL/EAI_WCLI1014/req"},

            //EAI_WSVI1017 : 웰스QR-AS 고객정보조회
            {"EAI_WSVI1017", "/mediate/KYOWON/W/SV/EAI_WSVI1017/req"},
            //EAI_WSVI1018 : 웰스QR-AS 접수정보조회
            {"EAI_WSVI1018", "/mediate/KYOWON/W/SV/EAI_WSVI1018/req"},

            //EAI_EOGI1004 : 마음의소리-선생님정보조회
            {"EAI_EOGI1004", "/mediate/KYOWON/E/OG/EAI_EOGI1004/req"}
        };

        public static string GetApiUrl(string api)
        {
            return HASH_URL_API[api].ToString();
        }
    }
    #endregion
    
    public class Header
    {
        public string STD_ETXT_UNQ_ID { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        public string STD_ETXT_IF_ID { get; set; }
        public string CHNL_MEDI_DV_CD { get; set; }
        public string STD_ETXT_AK_PRG_ID { get; set; }
        public string ERR_OC_YN { get; set; }
        public string RSP_MSG { get; set; }
        public string RSP_DTL_MSG { get; set; }
        public string LGN_USR_ID { get; set; }
        public string SEND_IP { get; set; }
        public string RCV_IP { get; set; }
        public string CLNT_STD_ETXT_SEND_T { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        public string STD_ETXT_SEND_T { get; set; }
        public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
        public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
    }

    #region API REQUEST BODY, RESPONSE BODY

    #region 공통 EAI_CBDI0001
    public class EAI_CBDI0001
    {
        public string name { get; set; }
    }

    public class EAI_CBDI0001_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string rtnCode { get; set; }
            public string rtnMessage { get; set; }
        }
    }
    #endregion

    #region 채움마일리지
    #region 플랜마일리지 EAI_ECLI1004
    public class EAI_ECLI1004
    {
        public string CNTR_CST_NO { get; set; }
    }

    public class EAI_ECLI1004_RESPONSE
    {
        public Header header = new Header();
        public IList<Body> body = new List<Body>();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {            
            public string MB_CST_NM { get; set; }
            public string SMTPL_GD_NM { get; set; }
            public string ORD_RCPDT { get; set; }
            public string PO_CLSF_NM { get; set; }
            public string CNTR_DTL_STAT_NM { get; set; }
            public long MLG_RV_AMT { get; set; }
            public long MLG_SL_AMT { get; set; }
            public long MLG_RES_AMT { get; set; }
            public string MLG_STAT_NM { get; set; }
            public string MLG_EXN_DT { get; set; }
            public string SMTPL_ID { get; set; }
            public int SMTPL_SN { get; set; }
        }
    }
    #endregion

    #region 플랜마일리지 EAI_ECLI1005
    public class EAI_ECLI1005
    {
        public string SMTPL_ID { get; set; }
        public int SMTPL_SN { get; set; }
        public string RV_USE_DV_CD { get; set; }
    }

    public class EAI_ECLI1005_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public int SN { get; set; }
            public string OC_DT { get; set; }
            public string SMTPL_RV_USE_NM { get; set; }
            public long MLG_RV_USE_AMT { get; set; }
            public long MLG_RES_AMT { get; set; }
            public string PD_CLSF_NM { get; set; }
        }
    }
    #endregion

    #region 플랜마일리지 EAI_ECLI1006
    public class EAI_ECLI1006
    {
        public string SMTPL_ID { get; set; }
        public int SMTPL_SN { get; set; }
    }

    public class EAI_ECLI1006_RESPONSE
    {
        public Header header = new Header();
        public IList<Body> body = new List<Body>();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public int SN { get; set; }
            public string OC_DT { get; set; }
            public string SMTPL_RV_USE_NM { get; set; }
            public long MLG_RV_USE_AMT { get; set; }
            public long MLG_RES_AMT { get; set; }
            public string PD_CLSF_NM { get; set; }
        }
    }
    #endregion

    #region 플랜마일리지 EAI_ECLI1013
    public class EAI_ECLI1013
    {
        public string CNTR_CST_NO { get; set; }
        public string ALL_YN { get; set; }
    }

    public class EAI_ECLI1013_RESPONSE
    {
        public Header header = new Header();
        public IList<Body> body = new List<Body>();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string MB_CST_NM { get; set; }
            public string SMTPL_GD_NM { get; set; }
            public string ORD_RCPDT { get; set; }
            public string PO_CLSF_NM { get; set; }
            public string CNTR_DTL_STAT_NM { get; set; }
            public long MLG_RV_AMT { get; set; }
            public long MLG_SL_AMT { get; set; }
            public long MLG_RES_AMT { get; set; }
            public string MLG_STAT_NM { get; set; }
            public string MLG_EXN_DT { get; set; }
            public string SMTPL_ID { get; set; }
            public int SMTPL_SN { get; set; }
        }
    }
    #endregion
    #endregion

    #region 에듀
    #region 에듀 EAI_ECUI1004
    public class EAI_ECUI1004
    {
        public string KWCNAM { get; set; }
        public long KWBRDT { get; set; }
        public string KWGEND { get; set; }
        public string KWCTL2 { get; set; }
    }

    public class EAI_ECUI1004_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string KWCNAM { get; set; }
            public string KWKKEY { get; set; }
            public string KWCDDD { get; set; }
            public string KWHAD1 { get; set; }
            public long AKTAMT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1005
    public class EAI_ECUI1005
    {
        public string COUPON_NO { get; set; }
        public string PASSWD { get; set; }
        public string PTNR_ID { get; set; }
    }

    public class EAI_ECUI1005_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public IList<DataDetail> DATALIST { get; set; }            
        }

        public class DataDetail
        {
            public string RESULT { get; set; }
            public string COUPON_NO { get; set; }
            public string RESULT_MSG { get; set; }
            public string PTNR_NM { get; set; }
            public string CENTER_NM { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1006
    public class EAI_ECUI1006
    {
        public string COMP_DT { get; set; }
        public string EXAM_NO { get; set; }
        public string P_NM { get; set; }
        public string C_NM { get; set; }
        public string C_SCL { get; set; }
        public string C_MOB_NO1 { get; set; }
        public string C_MOB_NO2 { get; set; }
        public string C_MOB_NO3 { get; set; }
        public string PTNR_ID { get; set; }
        public string COUPON_NO { get; set; }
    }

    public class EAI_ECUI1006_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public long operation { get; set; }
            public long success { get; set; }
            public long failure { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1008
    public class EAI_ECUI1008
    {
        public string COFNDSEQ { get; set; }
        public long AKDGUB { get; set; }
    }

    public class EAI_ECUI1008_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public int CURR_CNT { get; set; }
            public string ABLE_YN { get; set; }
            public int CUST_CNT { get; set; }
            public int TOT_CNT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1010
    public class EAI_ECUI1010
    {
        public string KWCNAM { get; set; }
        public long KWBRDT { get; set; }
        public string KWGEND { get; set; }
        public string KWCTL2 { get; set; }
    }

    public class EAI_ECUI1010_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public IList<DataDetail> DATALIST { get; set; }
        }

        public class DataDetail
        {
            public string KWCNAM { get; set; }
            public string KWKKEY { get; set; }
            public string KWCDDD { get; set; }
            public string KWHAD1 { get; set; }
            public long AKTAMT { get; set; }
            public string AKJYMD { get; set; }
            public int SORT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1011
    public class EAI_ECUI1011
    {
        public string CORP { get; set; }
        public string GUBN { get; set; }
        public string IDIV { get; set; }
        public string CGUB { get; set; }
        public string birth { get; set; }
        public string sex { get; set; }
        public string CONO { get; set; }
        public string name { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string tel3 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string post1 { get; set; }
        public string post2 { get; set; }
        public string zipcode1 { get; set; }
        public string zipcode2 { get; set; }
        public string zipcode3 { get; set; }
        public string PROG { get; set; }
        public string OPCD { get; set; }
        public string DEVD { get; set; }
        public string SFK_VAL { get; set; }
        public string SFK_VAL_IS_DTM { get; set; }
        public string CIK_VAL { get; set; }
        public string CIK_VAL_IS_DTM { get; set; }
    }

    public class EAI_ECUI1011_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string key { get; set; }
            public string safekey { get; set; }
            public string safekeydate { get; set; }
            public string success { get; set; }
            public string msg { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1014
    public class EAI_ECUI1014
    {
        public string DGNS_CPON_NO { get; set; }
        public string DGNS_TST_PSWD { get; set; }
        public string PTNR_ID { get; set; }
    }

    public class EAI_ECUI1014_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public IList<DataDetail> DATALIST { get; set; }
        }

        public class DataDetail
        {
            public string RESULT { get; set; }
            public string COUPON_NO { get; set; }
            public string RESULT_MSG { get; set; }
            public string PTNR_NM { get; set; }
            public string CENTER_NM { get; set; }
            public string LINK_SEQ { get; set; }
            public string BEF_ROUND { get; set; }
            public string BEF_EXAM_NO { get; set; }
            public string C_MOB_NO { get; set; }
            public string C_NM { get; set; }
            public string CHLNBDT { get; set; }
            public string CHLNGNDR { get; set; }
            public string CUSTZPCD { get; set; }
            public string CUSTADR1 { get; set; }
            public string CUSTADR2 { get; set; }
            public string PTNR_ID { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1017
    public class EAI_ECUI1017
    {
        public long COMP_DT { get; set; }
        public string EXAM_NO { get; set; }
        public string TYPE_CD { get; set; }
        public string C_NM { get; set; }
        public string C_SCHOOL { get; set; }
        public string C_MOB_NO1 { get; set; }
        public string C_MOB_NO2 { get; set; }
        public string C_MOB_NO3 { get; set; }
        public long PTNR_ID { get; set; }
    }

    public class EAI_ECUI1017_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string COUPON_NO { get; set; }
            public string RESULT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_ECUI1018
    public class EAI_ECUI1018
    {        
        public string COUPON_NO { get; set; }
        public string PASSWD { get; set; }
        public string PTNR_ID { get; set; }
    }

    public class EAI_ECUI1018_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public IList<DataDetail> DATALIST { get; set; }
        }

        public class DataDetail
        {
            public string RESULT { get; set; }
            public string COUPON_NO { get; set; }
            public string RESULT_MSG { get; set; }
            public string PTNR_NM { get; set; }
            public string CENTER_NM { get; set; }
            public string LINK_SEQ { get; set; }
            public string BEF_ROUND { get; set; }
            public string BEF_EXAM_NO { get; set; }
            public string C_MOB_NO { get; set; }
            public string C_NM { get; set; }
            public string CHLNBDT { get; set; }
            public string CHLNGNDR { get; set; }
            public string CUSTZPCD { get; set; }
            public string CUSTADR1 { get; set; }
            public string CUSTADR2 { get; set; }
            public string PTNR_ID { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_WCLI1012
    public class EAI_WCLI1012
    {
        public string MLG_TP_CD { get; set; }
        public string CNTR_CST_NO { get; set; }
    }

    public class EAI_WCLI1012_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public long TOT_MLG_RES_AMT { get; set; }
            public long TOT_MLG_EXT_AMT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_WCLI1013
    public class EAI_WCLI1013
    {
        public string CNTR_CST_NO { get; set; }
        public string MLG_TP_CD { get; set; }
    }

    public class EAI_WCLI1013_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string MLG_RV_NO { get; set; }
            public string PD_NM { get; set; }
            public string CNTR_NO { get; set; }
            public long CNTR_SN { get; set; }
            public string SL_DT { get; set; }
            public long MLG_RV_AMT { get; set; }
            public long MLG_SL_AMT { get; set; }
            public long MLG_RES_AMT { get; set; }
            public string MLG_RV_DT { get; set; }
            public string MLG_EXN_DT { get; set; }
            public string MLG_EXN_EXT_DT { get; set; }
        }
    }
    #endregion

    #region 에듀 EAI_WCLI1014
    public class EAI_WCLI1014
    {
        public string MLG_RV_NO { get; set; }
    }

    public class EAI_WCLI1014_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public long MLG_RES_AMT { get; set; }
            public string MLG_USE_DT { get; set; }
            public string PD_CLSF_NM { get; set; }
            public long MLG_SL_AMT { get; set; }
            public long MLG_USE_AMT { get; set; }
        }
    }
    #endregion
    #endregion

    #region 웰스QR
    #region 웰스QR EAI_WSVI1017
    public class EAI_WSVI1017
    {
        public string CNTR_NO { get; set; }
        public string CST_KNM { get; set; }
        public string HPNO { get; set; }
        public string PD_GRP_ID { get; set; }
        public string NEW_ADR_AIP { get; set; }
    }

    public class EAI_WSVI1017_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string CNTR_NO { get; set; }
            public string CST_KNM { get; set; }
            public string CNTR_DT { get; set; }
            public DataDetail PD_INF { get; set; }
            public string CRAL_LOCARA_TNO { get; set; }
            public string MEXNO_ENCR { get; set; }
            public string CRAL_IDV_TNO { get; set; }
            public string LOCARA_TNO { get; set; }
            public string EXNO_ENCR { get; set; }
            public string IDV_TNO { get; set; }
            public string NEW_ADR_ZIP { get; set; }
            public string RNADR { get; set; }
            public string RDADR { get; set; }
            public string ADR_DV_CD { get; set; }
            public string ADDR { get; set; }
            public string HPNO { get; set; }
            public string TELNO { get; set; }
            public string RCGVP_KNM { get; set; }
            public string BRYY_MMDD { get; set; }
            public string SEX_DV_CD { get; set; }
            public string CNTR_CST_NO { get; set; }
        }

        public class DataDetail
        {
            public string PD_CD { get; set; }
            public string PD_NM { get; set; }
        }
    }
    #endregion

    #region 웰스QR EAI_WSVI1018
    public class EAI_WSVI1018
    {
        public string CNTR_NO { get; set; }
    }

    public class EAI_WSVI1018_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string CNTR_NO { get; set; }
            public string IN_CHNL_DV_CD { get; set; }
            public string SV_BIZ_HCLSF_CD { get; set; }
            public string RCPDT { get; set; }
            public string AS_IST_OJ_NO { get; set; }
            public string SV_BIZ_DCLSF_CD { get; set; }
            public string SV_BIZ_DCLSF_NM { get; set; }
            public string CNSL_NO_CN { get; set; }
            public string CLTN_YN { get; set; }
            public string VST_CNFM_DTM { get; set; }
            public string VST_EXP_DTM { get; set; }
            public string CRAL_LOCARA_TNO { get; set; }
            public string MEXNO_ENCR { get; set; }
            public string CRAL_IDV_TNO { get; set; }
            public string LOCARA_TNO { get; set; }
            public string EXNO_ENCR { get; set; }
            public string IDV_TNO { get; set; }
            public string NEW_ADR_ZIP { get; set; }
            public string RNADR { get; set; }
            public string RDADR { get; set; }
            public string ADR_DV_CD { get; set; }
        }
    }
    #endregion
    #endregion

    #region 마음의소리
    #region 마음의소리 EAI_EOGI1004
    public class EAI_EOGI1004
    {
        public string PRTNR_NO { get; set; }
        public string PRTNR_KNM { get; set; }
    }

    public class EAI_EOGI1004_RESPONSE
    {
        public Header header = new Header();
        public Body body = new Body();
        public class Header
        {
            public string STD_ETXT_UNQ_ID { get; set; }
            public string STD_ETXT_IF_ID { get; set; }
            public string CHNL_MEDI_DV_CD { get; set; }
            public string STD_ETXT_AK_PRG_ID { get; set; }
            public string ERR_OC_YN { get; set; }
            public string RSP_MSG { get; set; }
            public string RSP_DTL_MSG { get; set; }
            public string LGN_USR_ID { get; set; }
            public string SEND_IP { get; set; }
            public string RCV_IP { get; set; }
            public string CLNT_STD_ETXT_SEND_T { get; set; }
            public string STD_ETXT_SEND_T { get; set; }
            public string RSP_SYS_STD_ETXT_RCV_T { get; set; }
            public string RSP_SYS_STD_ETXT_SEND_T { get; set; }
        }

        public class Body
        {
            public string RESULT { get; set; }
            public string PRTNR_KNM { get; set; }
            public string PRTNR_NO { get; set; }
        }
    }
    #endregion
    #endregion

    #endregion

    public abstract class FactoryController
    {
        public abstract IApiTypeFactory MakeApiTypeFactory(string gubun);
    }

    public class ConcreateApiFactory : FactoryController
    {
        public override IApiTypeFactory MakeApiTypeFactory(string gubun)
        {
            switch (gubun)
            {
                case "post":
                    return new PostApiClientHelper(); //POST API
                case "get":
                    return new PostApiClientHelper(); //GET API TO-BE : 구현예정
                default:
                    return new PostApiClientHelper();
            }
        }
    }

    public interface IApiTypeFactory
    {
        string ApiAsync(string url, Object obj, Object header);
    }

    class PostApiClientHelper : Controller, IApiTypeFactory
    {
        static HttpClient client = new HttpClient();

        public string ApiAsync(string url, Object body, Object header)
        {
            try
            {
                Dictionary<string, Object> dic = new Dictionary<string, object>();
                dic.Add("header", header);
                dic.Add("body", body);

                #region api url 생성 및 parameter jsonString으로 변환                
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string param = serializer.Serialize(dic); //모든 request를 처리할 수 있도록 객체를 jsonstring으로 변환
                #endregion

                var res = HttpClientHelper.apiRequest(url, param);
                return HttpClientHelper.streamEncode(res);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    #region httpClientHelper
    public static class HttpClientHelper
    {
        /// <summary>
        /// GET 방식 webapi 호출
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RequestGet(string url)
        {
            //WebRequest.CreateHttp(url).;
            using (var web = new WebClient())
            {
                web.Encoding = Encoding.UTF8;
                return web.DownloadString(url);
            }
        }

        /// <summary>
        /// POST방식 webapi 호출
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string RequestPost(string url, string data, string contentType = "application/json")
        {
            using (var web = new WebClient())
            {
                web.Encoding = Encoding.UTF8;
                if (!string.IsNullOrWhiteSpace(contentType))
                {
                    web.Headers["Content-Type"] = contentType;
                }

                return web.UploadString(url, "POST", data);
            }
        }

        public static HttpWebResponse apiRequest(String url, String postData)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var request = (HttpWebRequest)WebRequest.Create(url);

            Encoding euckr = Encoding.GetEncoding(65001);// 51949:  euc-kr    , 65001:utf-8
            var data = euckr.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Timeout = 5000;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var result = (HttpWebResponse)request.GetResponse();
            return result;
        }
        public static String apiGetRequest(String url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.Timeout = 5000;
            var result = (HttpWebResponse)request.GetResponse();

            Stream ReceiveStream = result.GetResponseStream();
            Encoding encode = Encoding.GetEncoding(65001); // 51949:  euc-kr    , 65001:utf-8

            string responseText = string.Empty;
            string reutrnText = string.Empty;
            using (StreamReader sr = new StreamReader(ReceiveStream))
            {
                responseText = sr.ReadToEnd();
            }

            char[] arr = responseText.ToArray();
            bool bln = true;
            foreach (char item in arr)
            {
                if (bln)
                {
                    if (item == '}')
                    {
                        reutrnText += item.ToString();
                        break;
                    }
                    else
                    {
                        reutrnText += item.ToString();
                    }
                }
            }
            return reutrnText;
        }
        public static String streamEncode(HttpWebResponse result)
        {
            Stream ReceiveStream = result.GetResponseStream();
            Encoding encode = Encoding.GetEncoding(65001); // 51949:  euc-kr    , 65001:utf-8

            StreamReader sr = new StreamReader(ReceiveStream, encode);
            string resultText = sr.ReadToEnd();
            return resultText;
        }
    }
    #endregion
}