using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using Unity;

namespace NodeCanvas.Tasks.Actions{

	public class ReturnActionTask : ActionTask{
        public BBParameter<Vector3> startLocation;
        private NavMeshAgent navAgent;

        protected override string OnInit(){
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}


		protected override void OnExecute(){
			//Tell the agent to return to the starting position
			Debug.Log("gotta return");
        }


		protected override void OnUpdate(){
			navAgent.SetDestination(startLocation.value);
			if(Vector3.Distance(agent.transform.position,startLocation.value) < 0.5)
			{
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