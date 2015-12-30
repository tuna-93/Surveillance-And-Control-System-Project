using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CSTest
{
    class NetListenerServer : IDisposable
    {
        /// <summary>
        /// 서버로 연결할 때 필요한 포트 번호 필드입니다.
        /// </summary>
        private ushort m_PortNumber;

        /// <summary>
        /// 서버로 연결할 때 필요한 포트 번호를 반환합니다. 포트가 열린 상태가 아닐 경우 -1을 반환합니다.
        /// </summary>
        public int PortNumber
        {
            get
            {
                if (m_Listener == null)
                    return -1;
                return m_PortNumber;
            }
        }

        /// <summary>
        /// 연결을 수신할 TcpListener 입니다.
        /// </summary>
        private TcpListener m_Listener;

        /// <summary>
        /// 연결 수신을 받아들이는 쓰레드입니다.
        /// </summary>
        private Thread m_ConnectionAcceptThread;

        /// <summary>
        /// 지정한 포트번호로 서버를 열어, 연결 수신을 시작합니다.
        /// </summary>
        /// <param name="portNumber">열 포트번호입니다.</param>
        public void OpenPort(ushort portNumber)
        {
            m_PortNumber = portNumber;
            m_Listener = new TcpListener(IPAddress.Any, portNumber);
            m_Listener.Start();
        }

        /// <summary>
        /// 포트를 닫아 연결 수신을 종료합니다. 이미 받아들인 연결은 그대로 남습니다.
        /// </summary>
        public void ClosePort()
        {
            m_Listener.Stop();
            m_Listener = null;
        }

        /// <summary>
        /// 받아들인 모든 연결을 종료합니다. 연결 수신은 그대로 남습니다.
        /// </summary>
        public void CloseConnection()
        {

        }

        /// <summary>
        /// 연결 수신을 종료하고 받아들인 모든 연결을 다 종료합니다.
        /// </summary>
        public void Dispose()
        {
            ClosePort();
            CloseConnection();
        }
    }
}
