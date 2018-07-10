using System;
using BasicFramework.Common;

namespace BasicFramework.MessageContracts
{
    public class Response<T>
    {
        private bool _isSuccess = false;

        public ErrorCode ErrorCode { get; set; }

        public bool IsSuccess
        {
            get
            {
                return this._isSuccess;
            }
            set
            {
                this._isSuccess = value;
            }
        }

        public Exception Exception { get; set; }

        public string SuccessMessage { get; set; }

        private T _result;

        public T Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}