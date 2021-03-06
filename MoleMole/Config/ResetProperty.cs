﻿namespace MoleMole.Config
{
    using MoleMole;
    using System;

    [GeneratePartialHash(CombineGeneratedFile=true)]
    public class ResetProperty : ConfigAbilityAction, IHashable
    {
        public string Property;

        public override void Call(ActorAbilityPlugin abilityPlugin, ConfigAbilityAction actionConfig, ActorAbility instancedAbility, ActorModifier instancedModifier, BaseAbilityActor target, BaseEvent evt)
        {
            abilityPlugin.ResetPropertyHandler(actionConfig, instancedAbility, instancedModifier, target, evt);
        }

        public override bool GetDebugOutput(ActorAbility instancedAbility, ActorModifier instancedModifier, BaseAbilityActor target, BaseEvent evt, ref string output)
        {
            output = string.Format("{0} 对 {1} 重置属性修改 {2}", Miscs.GetDebugActorName(instancedAbility.caster), Miscs.GetDebugActorName(target), this.Property);
            return true;
        }

        public void ObjectContentHashOnto(ref int lastHash)
        {
            HashUtils.ContentHashOnto(this.Property, ref lastHash);
            HashUtils.ContentHashOnto((int) base.Target, ref lastHash);
            if ((base.TargetOption != null) && (base.TargetOption.Range != null))
            {
                HashUtils.ContentHashOnto(base.TargetOption.Range.isDynamic, ref lastHash);
                HashUtils.ContentHashOnto(base.TargetOption.Range.fixedValue, ref lastHash);
                HashUtils.ContentHashOnto(base.TargetOption.Range.dynamicKey, ref lastHash);
            }
            if (base.Predicates != null)
            {
                foreach (ConfigAbilityPredicate predicate in base.Predicates)
                {
                    if (predicate is IHashable)
                    {
                        HashUtils.ContentHashOnto((IHashable) predicate, ref lastHash);
                    }
                }
            }
        }
    }
}

