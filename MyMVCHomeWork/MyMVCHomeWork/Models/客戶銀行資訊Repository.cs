using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MyMVCHomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{

        /// <summary>
        /// 複寫底曾取得所有資料，並過濾已刪除資料
        /// </summary>
        /// <returns></returns>
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p=>p.IsDelete==false);
        }

        /// <summary>
        /// 取得指定銀行資料ID的銀行資料
        /// </summary>
        /// <param name="parBankID">銀行資料ID</param>
        /// <returns></returns>
        public 客戶銀行資訊 GetBankDataByBankID(int? parBankID)
        {
            return this.All().Where(p => p.Id == parBankID).SingleOrDefault(); ;
        }


        /// <summary>
        /// 取得指定客戶ID的銀行資料
        /// </summary>
        /// <param name="parCusID">客戶ID</param>
        /// <returns></returns>
        public IQueryable<客戶銀行資訊> GetBankDataByCusID(int parCusID)
        {
           return this.All().Where(p => p.客戶Id == parCusID);
        }

	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}