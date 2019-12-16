





namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNQuerySV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 库存可用量查询 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class ECNWHQuery
	{
	    #region Fields
		private System.String bOMItemInfo;
		private System.String contextInfo;
		
	    #endregion
		
	    #region constructor
		public ECNWHQuery()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// BOM物料信息	
		/// 库存可用量查询.Misc.BOM物料信息
		/// </summary>
		/// <value></value>
		public System.String BOMItemInfo
		{
			get
			{
				return this.bOMItemInfo;
			}
			set
			{
				bOMItemInfo = value;
			}
		}
		/// <summary>
		/// 执行上下文	
		/// 库存可用量查询.Misc.执行上下文
		/// </summary>
		/// <value></value>
		public System.String ContextInfo
		{
			get
			{
				return this.contextInfo;
			}
			set
			{
				contextInfo = value;
			}
		}
	    #endregion
		
	    #region do method 
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.Supported)]
		[Logger]
		[Authorize]
		public System.String Do()
		{	
		    BaseStrategy selector = Select();	
				System.String result =  (System.String)selector.Execute(this);	
		    
			return result ; 
		}			
	    #endregion 					
	} 		
}
