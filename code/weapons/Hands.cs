using Sandbox;

[Library( "notaweapon_hands", Title = "Hands", Spawnable = false )]
partial class Hands : Weapon
{
	public override string ViewModelPath => "models/firstperson/temp_punch/temp_punch.vmdl";
	public override float PrimaryRate => 2.0f;
	public override float SecondaryRate => 2.0f;

	public override bool CanReload()
	{
		return false;
	}

	public override void AttackPrimary()
	{
	}

	public override void AttackSecondary()
	{
	}

	public override void OnCarryDrop( Entity dropper )
	{
	}

	public override void SimulateAnimator( PawnAnimator anim )
	{
		anim.SetParam( "holdtype", 5 );
		anim.SetParam( "aimat_weight", 1.0f );
	}
}
