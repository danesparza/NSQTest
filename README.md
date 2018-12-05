# NSQTest
Simple [NSQ](https://github.com/nsqio/nsq) producer / consumer proof of concept

Uses [Refit](https://reactiveui.github.io/refit/) on the [producer side](https://github.com/danesparza/NSQTest/blob/master/NSQ.Producer/Program.cs#L11) to call the simple HTTP API of NSQ.

Uses [NsqSharp](https://github.com/judwhite/NsqSharp) on the [consumer side](https://github.com/danesparza/NSQTest/blob/master/NSQ.Consumer/MessageHandler.cs#L12-L42) to process messages and handle success/failure/requeue
