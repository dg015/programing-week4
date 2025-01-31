using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	public class SearchActionTask : ActionTask{
		private NavMeshAgent navAgent;
		public Vector3 target;
		public BBParameter<Vector3> startLocation;
		public float searchRadius;

        protected override string OnInit(){
			startLocation.value = agent.transform.position;
            navAgent = agent.GetComponent<NavMeshAgent>();
			//target = new Vector3(Random.Range(minXRange, maxXRange), 0, Random.Range(minZRange, maxZRange));
			
			return null;
		}

		protected override void OnExecute(){

            target = Random.insideUnitSphere * searchRadius + agent.transform.position;
			NavMeshHit hit;
			if(!NavMesh.SamplePosition(target, out hit, searchRadius, NavMesh.AllAreas))
			{
                //EndAction(true);
                return;
			}
            navAgent.SetDestination(hit.position);
            //Choose a random destination on the navmesh
            //Set the path to that position
        }

		protected override void OnUpdate(){
			//When they have arrived then end the task
			Debug.Log("IM WORKING");
            if (!navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
				Debug.Log("got here");
                EndAction(true);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}