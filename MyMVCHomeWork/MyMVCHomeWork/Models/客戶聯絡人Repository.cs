using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MyMVCHomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{

        /// <summary>
        /// 複寫取得所有資料，並過濾已刪除資料
        /// </summary>
        /// <returns></returns>
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }


        /// <summary>
        /// 取得指定聯絡人ID的資料
        /// </summary>
        /// <param name="parContactID">聯絡人ID</param>
        /// <returns></returns>
        public 客戶聯絡人 GetCusContactByContactID(int? parContactID)
        {
            return this.All().Where(p => p.Id == parContactID).SingleOrDefault();
        
        }

        /// <summary>
        /// 取得指定客戶ID的所有聯絡人資料
        /// </summary>
        /// <param name="parCusID">客戶ID</param>
        /// <returns></returns>
        public IQueryable<客戶聯絡人> GetCusContactByCusID(int parCusID)
        {
           
            return this.All().Where(p => p.客戶Id == parCusID);

        }
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}