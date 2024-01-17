using FluentValidation;

namespace MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(command => command.ActorId).GreaterThan(0);
        }
    }
}