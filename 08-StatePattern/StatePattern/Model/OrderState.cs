using System;

namespace StatePattern.Model
{
    public abstract class OrderState
    {
        public virtual bool CanModify() => false;
        public virtual OrderState Confirm() => throw new InvalidOperationException();
        public virtual OrderState Ship() => throw new InvalidOperationException();
    }

    public class DraftState : OrderState
    {
        public override bool CanModify() => true;
        public override OrderState Confirm()
        {
            return new ConfirmedState();
        }
    }
    public class ConfirmedState : OrderState
    {
        public override OrderState Ship()
        {
            return new ShippedState();
        }
    }
    public class ShippedState : OrderState
    {

    }
}