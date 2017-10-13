using System;
using System.Data;

namespace Dapper
{
    public partial class DynamicParameters
    {
        /// <summary>
        /// 
        /// </summary>
        public sealed class ParamInfo
        {

            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public object Value { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public ParameterDirection ParameterDirection { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DbType? DbType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int? Size { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public IDbDataParameter AttachedParam { get; set; }
            /// <summary>
            /// 
            /// </summary>
            internal Action<object, DynamicParameters> OutputCallback { get; set; }
            internal object OutputTarget { get; set; }
            internal bool CameFromTemplate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public byte? Precision { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public byte? Scale { get; set; }
        }
    }
}
