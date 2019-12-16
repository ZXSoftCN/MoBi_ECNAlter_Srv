

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
	public class ModifyMOPickListTest
	{
		private Proxy.ModifyMOPickListProxy obj = new Proxy.ModifyMOPickListProxy();

		public ModifyMOPickListTest()
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