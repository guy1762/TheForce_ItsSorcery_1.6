using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using TheForce_ItsSorcery.Abilities;
using Verse;
using Verse.AI;

namespace TheForce_ItsSorcery.Abilities
{
    internal class CompAbility_StopMentalState : CompAbilityEffect
    {
        public new CompProperties_StopMentalState Props => (CompProperties_StopMentalState)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            if (target.Thing is Pawn && target.Pawn.InMentalState)
            {
                target.Pawn.MentalState.RecoverFromState();
                target.Pawn.jobs.EndCurrentJob(JobCondition.InterruptForced);
            }
        }
    }




    public class CompProperties_StopMentalState : CompProperties_AbilityEffect
    {
        public CompProperties_StopMentalState()
        {
            compClass = typeof(CompAbility_StopMentalState);
        }
    }

}
