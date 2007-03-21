using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Modbus.Device;
using System.IO.Ports;
using System.Threading;

namespace Modbus.IntegrationTests
{
	[TestFixture]
	public class ModbusRtuFixture : ModbusMasterFixture
	{
		[TestFixtureSetUp]
		public override void Init()
		{
			base.Init();

			SetupSlaveSerialPort();
			Slave = ModbusSerialSlave.CreateRtu(SlaveAddress, SlaveSerialPort);
			StartSlave();

			SetupMasterSerialPort(ModbusMasterFixture.DefaultMasterSerialPortName);
			Master = ModbusSerialMaster.CreateRtu(MasterSerialPort);
		}

		[Test]
		public override void ReadCoils()
		{
			base.ReadCoils();
		}

		[Test]
		public override void Read0Coils()
		{
			base.Read0Coils();
		}

		[Test]
		public override void ReadHoldingRegisters()
		{
			base.ReadHoldingRegisters();
		}

		[Test]
		public override void ReadInputs()
		{
			base.ReadInputs();
		}

		[Test]
		public override void WriteSingleCoil()
		{
			base.WriteSingleCoil();
		}

		[Test]
		public override void WriteMultipleCoils()
		{
			base.WriteMultipleCoils();
		}

		[Test]
		public override void WriteSingleRegister()
		{
			base.WriteSingleRegister();
		}

		[Test]
		public override void WriteMultipleRegisters()
		{
			base.WriteMultipleRegisters();
		}

		[Test]
		public void ReturnQueryData()
		{
			Assert.IsTrue(((ModbusSerialMaster) Master).ReturnQueryData(SlaveAddress, 18));
			Assert.IsTrue(((ModbusSerialMaster) Master).ReturnQueryData(SlaveAddress, 5));
		}
	}
}