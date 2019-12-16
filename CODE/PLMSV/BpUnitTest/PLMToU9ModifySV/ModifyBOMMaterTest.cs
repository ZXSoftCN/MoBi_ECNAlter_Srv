

namespace UFIDA.U9.Safor.VW.PLMSV.PLMToU9ModifySV
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.IO;
	using NUnit.Framework;
	
	/// <summary>
	/// Business operation test
	/// </summary> 
	[TestFixture]		
	public class ModifyBOMMaterTest
	{
		private Proxy.ModifyBOMMaterProxy obj = new Proxy.ModifyBOMMaterProxy();

		public ModifyBOMMaterTest()
		{
		}
		#region AutoTestCode ...
		[Test]
		public void TestDo()
		{
			obj.Do() ;  
		
		}
		#endregion 				
	}
	
}