using System;
using System.Collections.Generic;
using System.Text;
using Framework.Domain;

namespace CollectionOfEntities.Model
{
    public class DecisionHierarchy : AggregateRoot<long>
    {
        private List<Step> _steps;
        public LoanTypes LoanType { get; private set; }
        public IReadOnlyList<Step> Steps => _steps.AsReadOnly();
        protected DecisionHierarchy() { }
        public DecisionHierarchy(long id, LoanTypes loanType, List<Step> steps) : base(id)
        {
            this._steps = steps;
            this.LoanType = loanType;
        }

        public void UpdateSteps(List<Step> steps)
        {
            this._steps = steps;
        }
    }
}
