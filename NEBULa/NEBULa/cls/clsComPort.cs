using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsComPort
    {
        public static bool InitCOM(SerialPort ComPort, int Port)
        {
            try
            {
                ComPort.PortName = "COM" + Port.ToString();
                ComPort.BaudRate = 115200;
                ComPort.Parity = Parity.None;
                ComPort.DataBits = 8;
                ComPort.StopBits = StopBits.One;
                ComPort.ReadBufferSize = 2046;
                //ComPort.Handshake = Handshake.RequestToSend;
                //ComPort.ReceivedBytesThreshold = 10;

                ComPort.NewLine = Environment.NewLine;
                ComPort.DtrEnable = true;
                ComPort.RtsEnable = true;
                ComPort.ReadTimeout = 20;
                ComPort.WriteTimeout = 20;

                ComPort.Open();
                return true;
            }
            catch (Exception

                e)
            {
                return false;
            }
        }


        public static void close(SerialPort ComPort)
        {
            try
            {
                if (null != ComPort)
                {
                    try
                    {
                        ComPort.Close();
                    }
                    catch
                    {
                    }
                    ComPort = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
