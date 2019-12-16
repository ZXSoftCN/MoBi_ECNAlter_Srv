





namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 创建ECN变更纪录 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class CreatePLMECN
	{
	    #region Fields
		private System.String eCNAlterRequest;
		private System.String contextInfo;
		
	    #endregion
		
	    #region constructor
		public CreatePLMECN()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// ECN变更请求	
		/// 创建ECN变更纪录.Misc.ECN变更请求
		/// </summary>
		/// <value></value>
		public System.String ECNAlterRequest
		{
			get
			{
				return this.eCNAlterRequest;
			}
			set
			{
				eCNAlterRequest = value;
			}
		}
		/// <summary>
		/// 执行上下文	
		/// 创建ECN变更纪录.Misc.执行上下文
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
		[Transaction(UFSoft.UBF.Transactions.TransactionOption.Required)]
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
