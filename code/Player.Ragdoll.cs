using Sandbox;

partial class SandboxPlayer
{
	private void BecomeRagdollOnClient( Vector3 velocity, DamageFlags damageFlags, Vector3 forcePos, Vector3 force, int bone )
	{
		ModelEntity ragdoll = new ModelEntity( "models/citizen/citizen.vmdl" );
		ragdoll.Tags.Add( "Ragdoll" );
		ragdoll.Transform = Transform;
		ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
		ragdoll.CollisionGroup = CollisionGroup.Prop;
		ragdoll.CopyBonesFrom( this );

		foreach ( var child in Children )
		{
			if ( !child.Tags.Has( "clothes" ) ) continue;
			if ( child is not ModelEntity e ) continue;

			var model = e.GetModelName();

			var clothing = new ModelEntity();
			clothing.SetModel( model );
			clothing.SetParent( ragdoll, true );
			clothing.RenderColor = e.RenderColor;
			clothing.CopyBodyGroups( e );
			clothing.CopyMaterialGroup( e );
		}

		ragdoll.Velocity = (velocity) * 20;
		ragdoll.DeleteAsync( 60.0f );
	}
}
