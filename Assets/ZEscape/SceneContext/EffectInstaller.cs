using UnityEngine;
using Zenject;
using ZEscape.VFX;

public class EffectInstaller : ScriptableObjectInstaller<EffectInstaller>
{
    [SerializeField] private BulletImpactEffect _bulletImpactEffect;
    [SerializeField] private BonusEffect _bonusEffect;
    public override void InstallBindings()
    {
        Container.BindFactory<Vector3, BulletImpactEffect, BulletImpactEffect.Factory>().FromMonoPoolableMemoryPool(
           x => x.WithInitialSize(20).FromComponentInNewPrefab(_bulletImpactEffect).UnderTransformGroup("BulletImpactEffect"));

        Container.BindFactory<Vector3, BonusEffect, BonusEffect.Factory>().FromMonoPoolableMemoryPool(
          x => x.WithInitialSize(20).FromComponentInNewPrefab(_bonusEffect).UnderTransformGroup("BonusEffect"));
    }
}
