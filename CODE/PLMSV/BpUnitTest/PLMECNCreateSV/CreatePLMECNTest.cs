﻿

namespace UFIDA.U9.Safor.VW.PLMSV.PLMECNCreateSV
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
	public class CreatePLMECNTest
	{
		private Proxy.CreatePLMECNProxy obj = new Proxy.CreatePLMECNProxy();

		public CreatePLMECNTest()
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