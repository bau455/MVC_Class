using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MyMVCHomeWork.Models
{   
	public  class vw_CusBankContactQtyRepository : EFRepository<vw_CusBankContactQty>, Ivw_CusBankContactQtyRepository
	{

	}

	public  interface Ivw_CusBankContactQtyRepository : IRepository<vw_CusBankContactQty>
	{

	}
}