using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MyMVCHomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        /// <summary>
        /// 複寫底層，並過濾掉有刪除其標的資料
        /// </summary>
        /// <returns></returns>
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p=>p.IsDelete==false);
        }


        /// <summary>
        /// 傳入客戶ID參數找客戶資料
        /// </summary>
        /// <param name="parCusID">客戶ID</param>
        /// <returns></returns>
        public 客戶資料 GetCusDataByID(int? parCusID) {
            return this.All().Where(p => p.Id == parCusID).SingleOrDefault();
        
        }
        

	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}