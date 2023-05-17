using System;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
namespace doAn

{
    public partial class Form1 : Form
    {
        private MqttClient mqttClient;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // tạo mqtt client
            mqttClient = new MqttClient();

            //kết nối và subcrice vào topic 
            mqttClient.Connect();
            mqttClient.Subscribe("stm32h755/test");

            //Đăng ký sự kiện nhận dữ liệu từ AWS IOT CORE
            
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            // ngắt kết nối mqtt
            mqttClient.Disconnect();
        }

        private void MqttClient_MessageReceived(string topic, string message)
        {
            // Xử lý dữ liệu nhận được từ AWS IoT Core
            if (topic == "your/topic")
            {
                if (message == "1")
                {
                    // Đèn được bật
                    UpdateStatusLabel("Đèn đang bật");
                }
                else if (message == "0")
                {
                    // Đèn được tắt
                    UpdateStatusLabel("Đèn đã tắt");
                }
            }
        }

        private void UpdateStatusLabel(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { statusLabel.Text = status; }));
            }
            else
            {
                statusLabel.Text = status;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnBat_Click(object sender, EventArgs e)
        {
            // gửi tin nhắn bật đèn lên aws iot core
            mqttClient.Publish("stm32h755/test", "1");
        }

        private void btnTat_Click(object sender, EventArgs e)
        {
            // gửi tin nhắn bật đèn lên aws iot core
            mqttClient.Publish("stm32h755/test", "1");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}