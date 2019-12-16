namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
{
	using System;
	using System.Collections.Generic;
	using System.Text; 
	using UFSoft.UBF.AopFrame;	
	using UFSoft.UBF.Util.Context;

	/// <summary>
	/// ModifyBOMMater partial 
	/// </summary>	
	public partial class ModifyBOMMater 
	{	
		internal BaseStrategy Select()
		{
			return new ModifyBOMMaterImpementStrategy();	
		}		
	}
	
	#region  implement strategy	
	/// <summary>
	/// Impement Implement
	/// 
	/// </summary>	
	internal partial class ModifyBOMMaterImpementStrategy : BaseStrategy
	{
		public ModifyBOMMaterImpementStrategy() { }

		public override object Do(object obj)
		{						
			ModifyBOMMater bpObj = (ModifyBOMMater)obj;
			
			//get business operation context is as follows
			//IContext context = ContextManager.Context	
			
			//auto generating code end,underside is user custom code
			//and if you Implement replace this Exception Code...
			throw new NotImplementedException();
		}		
	}

	#endregion
	
	
}