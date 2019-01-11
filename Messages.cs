using System;

namespace WinTailC {
    public class ContinueProcessing {}

    public class Input {
        public string Reason { get; private set; }
        public Input (string reason) {
            this.Reason = reason;
        }
        public override string ToString() {
            return this.Reason;
        }
    }
    public class ErrorInput : Input {
        public ErrorInput (string reason) : base(reason) {}
    }
    public class EmptyInput : ErrorInput {
        public EmptyInput(string reason) : base(reason) {}
    }

    public class InvalidInput : ErrorInput {
        public InvalidInput(string reason) : base(reason) {}
    }

    public class ValidInput : Input {
        public ValidInput(string reason) : base(reason) {}
    }
}