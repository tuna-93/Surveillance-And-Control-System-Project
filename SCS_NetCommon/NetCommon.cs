using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SCS_NetCommon
{
    /// <summary>
    /// 네트워크를 통해 전송될 객체입니다.
    /// </summary>
    [Serializable]
    public class SendingObj : ISerializable
    {
        /// <summary>
        /// 예외 메시지를 가져옵니다. 없을 경우 null입니다.
        /// </summary>
        public string ExceptionMessage { get; private set; }

        /// <summary>
        /// 전송 유형을 나타냅니다.
        /// </summary>
        public SendingType SendingType { get; private set; }

        /// <summary>
        /// 같이 전송되는 추가 정보 객체입니다. 없을 경우 null입니다.
        /// </summary>
        public object TagData { get; private set; }

        /// <summary>
        /// 전송 유형과 같이 전송할 객체, 서버 또는 클라이언트에서 발생한 예외 메시지를 지정하여 초기화합니다.
        /// </summary>
        /// <param name="sendingType">전송 유형입니다.</param>
        /// <param name="tagData">같이 전송할 객체입니다.</param>
        /// <param name="exceptionStr">발생한 예외 메시지입니다.</param>
        public SendingObj(SendingType sendingType, object tagData = null, string exceptionStr = null)
        {
            SendingType = sendingType;
            TagData = tagData;
            ExceptionMessage = exceptionStr;
        }

        /// <summary>
        /// ISerializable를 통해 구현하는 직렬화입니다.
        /// </summary>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ExceptionMessage", ExceptionMessage);
            info.AddValue("SendingType", SendingType);
            info.AddValue("TagData", TagData);
        }

        /// <summary>
        /// 지정된 Stream에 현재 객체를 직렬화하여 씁니다.
        /// </summary>
        /// <param name="serializeStream">직렬화에 쓸 스트림입니다.</param>
        public void Serialize(Stream serializeStream)
        {
            if (serializeStream == null)
                throw new ArgumentNullException();

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(serializeStream, this); // 직렬화합니다.
        }

        /// <summary>
        /// 지정된 Stream에서 읽어들여 역직렬화합니다.
        /// </summary>
        /// <param name="deserializeStream">읽어들일 스트림입니다.</param>
        public static SendingObj Deserialize(Stream deserializeStream)
        {
            if (deserializeStream == null)
                throw new ArgumentNullException();

            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(deserializeStream) as SendingObj; // 역직렬화한 뒤 SendingObj로 캐스팅하여 반환합니다.
        }
    }

    /// <summary>
    /// 전송 유형을 나타납니다.
    /// </summary>
    public enum SendingType
    {
        // --- 서버에서 클라이언트로 전송됩니다. ---

        /// <summary>
        /// 서버에서 클라이언트로 전송되는 화면에 표시될 메시지 입니다.
        /// </summary>
        SToC_SpreadMessage,

        // --- 클라이언트에서 서버로 전송됩니다. ---

        /// <summary>
        /// 클라이언트에서 서버로 전송되는 메시지 전달 요청입니다.
        /// </summary>
        CToS_SpreadMessageReq
    }
}
