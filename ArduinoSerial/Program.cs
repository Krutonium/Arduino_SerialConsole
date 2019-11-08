using System;
using System.IO.Ports;
namespace ArduinoSerial
{
    class Program
    {
        private static SerialPort _serialport;
        static void Main(string[] args)
        {
            string[] ports = SerialPort.GetPortNames();
            Console.WriteLine("Found Ports:");
            int portnum  = 0;
            int intChoice;
            if (ports.Length == 0)
            {
                
            }
            foreach (var port in ports)
            {
                Console.WriteLine(portnum + ": " + port);
                portnum += 1;
            }
            _serialport = new SerialPort();
            if (ports.Length == 1)
            {
                Console.WriteLine("Assuming only port is correct.");
                _serialport.PortName = ports[0];
            }
            else
            {
                Console.WriteLine("Which Port?");
                try
                {
                    string choice = Console.ReadKey().ToString();
                    Int32.TryParse(choice, out intChoice);
                    _serialport.PortName = ports[intChoice];
                } catch (Exception e)
                {
                    
                }
                
            }
            _serialport.BaudRate = 9600;
            _serialport.DataReceived += SerialportOnDataReceived;
            _serialport.Open();
            
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "" == false)
                {
                    _serialport.Write(text);
                }
            }
            
        }

        private static void SerialportOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string text = _serialport.ReadExisting();
            if (text == "" == false)
            {
                Console.Write(text);
            }
        }
    }
}