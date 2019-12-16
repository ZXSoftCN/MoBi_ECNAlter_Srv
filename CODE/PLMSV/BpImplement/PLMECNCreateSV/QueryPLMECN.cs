





namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// ECN变更纪录对比查询 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class QueryPLMECN
	{
	    #region Fields
		private System.String eCNAlterInfo;
		private System.String contextInfo;
		
	    #endregion
		
	    #region constructor
		public QueryPLMECN()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// ECN变更对比查询	
		/// ECN变更纪录对比查询.Misc.ECN变更对比查询
		/// </summary>
		/// <value></value>
		public System.String ECNAlterInfo
		{
			get
			{
				return this.eCNAlterInfo;
			}
			set
			{
				eCNAlterInfo = value;
			}
		}
		/// <summary>
		/// 执行上下文	
		/// ECN变更纪录对比查询.Misc.执行上下文
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
