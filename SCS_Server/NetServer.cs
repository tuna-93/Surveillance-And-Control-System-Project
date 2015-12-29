using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTest
{
    class NetListenerServer : IDisposable
    {
        /// <summary>
        /// 서버로 연결할 때 필요한 포트 번호 필드입니다.
        /// </summary>
        private readonly int int_portNumber;

        /// <summary>
        /// 서버로 연결할 때 필요한 포트 번호를 반환합니다.
        /// </summary>
        public int Port { get { return int_portNumber; } }

        /// <summary>
        /// 포트 번호를 지정해 서버 객체를 생성합니다.
        /// </summary>
        /// <param name="port">열 포트번호입니다.</param>
        public NetListenerServer(int port)
        {
            int_portNumber = port;
        }

        /// <summary>
        /// 지정한 포트번호를 열어, 연결 수신을 시작합니다.
        /// </summary>
        public void PortOpen()
        {

        }

        /// <summary>
        /// 열었던 포트를 닫고 모든 연결을 닫습니다.
        /// </summary>
        public void PortClose()
        {

        }

        public void Dispose()
        {
            PortClose();
        }
    }
}
