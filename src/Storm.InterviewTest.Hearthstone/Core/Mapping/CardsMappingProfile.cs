
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Domain;
using Storm.InterviewTest.Hearthstone.Core.Services;
using Storm.InterviewTest.Hearthstone.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Mapping
{
    public class CardsMappingProfile : Profile
	{
    	public CardsMappingProfile()
		{   
			CreateMap<ICard, CardModel>()
                .ForMember(x => x.PlayerClass, opt => opt.ResolveUsing<HeroResolver>())
                .ForMember(m => m.PlayerClassText, opt =>
                {
                    opt.NullSubstitute("Neutral");
                    opt.MapFrom(m => m.PlayerClass);
                })
                .Include<Card,CardModel>();
            

		    CreateMap<Card, CardModel>()
                .Include<MinionCard, MinionModel>()
                .Include<WeaponCard, WeaponModel>()
                .Include<SpellCard, SpellModel>();

		    CreateMap<MinionCard, MinionModel>()
                .Include<HeroCard, HeroModel>();

		    CreateMap<WeaponCard, WeaponModel>();

		    CreateMap<SpellCard, SpellModel>();

            CreateMap<HeroCard, HeroModel>()
                .ForMember(x => x.PlayerClass, opt => opt.Ignore()); 
	    }
    }
}