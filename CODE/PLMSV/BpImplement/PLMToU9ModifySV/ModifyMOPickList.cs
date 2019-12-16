





namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Reflection;
	using UFSoft.UBF.AopFrame; 	

	/// <summary>
	/// 修改生产备料服务 business operation
	/// 
	/// </summary>
	[Serializable]	
	public partial class ModifyMOPickList
	{
	    #region Fields
		private System.String pLMECNInfo;
		private System.String contextInfo;
		
	    #endregion
		
	    #region constructor
		public ModifyMOPickList()
		{}
		
	    #endregion

	    #region member		
		/// <summary>
		/// ECN变更信息	
		/// 修改生产备料服务.Misc.ECN变更信息
		/// </summary>
		/// <value></value>
		public System.String PLMECNInfo
		{
			get
			{
				return this.pLMECNInfo;
			}
			set
			{
				pLMECNInfo = value;
			}
		}
		/// <summary>
		/// 执行上下文	
		/// 修改生产备料服务.Misc.执行上下文
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
