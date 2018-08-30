using System.Collections.Generic;
using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D
{
	public class Bootstrapper : MonoBehaviour
	{

		public GameObject nodeAvatarPrefab;
		public GameObject nodeLabelAvatarPrefab;
		public GameObject edgeAvatarPrefab;
		public GameObject edgeLabelAvatarPrefab;

		IGraph graph;
				
		List<IObserver> observers = new List<IObserver>();

		List<IUpdatable> updatables = new List<IUpdatable>();

		List<IUpdatable> fixedUpdatables = new List<IUpdatable>();

		void Start()
		{
			this.graph = new Core.Graph.Graph();

			this.setupImport();
			this.setupAvatarFactories();
			this.setupForces();
			this.setupInputScanners();

			EventPublisher.Publish(new EIImport(Application.dataPath + "/ImportDataExamples/Intro/", "csv"));
		}

		void Update()
		{
			foreach(IUpdatable updatable in this.updatables)
			{
				updatable.Update();
			}
		}

		void FixedUpdate()
		{
			foreach (IUpdatable updatable in this.fixedUpdatables)
			{
				updatable.Update();
			}
		}
		void setupImport()
		{
			IFactoryGraphElement<Core.Graph.Node> nodeFactory = new Core.Graph.FactoryNode();
			IFactoryGraphElement<Core.Graph.Edge> edgeFactory = new Core.Graph.FactoryEdge(this.graph);

			IRecordsImporter recordsImporter = new Backend.RecordsImporter<Core.Graph.Node, Core.Graph.Edge>();

			IObserver importManager = new Core.Graph.ImportManager(this.graph, recordsImporter, nodeFactory, edgeFactory);

			this.observers.Add(importManager);
		}

		void setupAvatarFactories()
		{
			this.observers.Add(new Frontend.Avatars.FactoryNodeAvatar(this.nodeAvatarPrefab, this.nodeLabelAvatarPrefab));
			this.observers.Add(new Frontend.Avatars.FactoryEdgeAvatar(this.edgeAvatarPrefab, this.edgeLabelAvatarPrefab));
		}

		void setupForces()
		{

			IForce centralForce = new Frontend.Physics.ForceCentral(new Frontend.RegistryNodeAvatar(this.graph));
			this.fixedUpdatables.Add(centralForce);
			this.observers.Add(new Frontend.Physics.ForceFactorListener<EISliderCentralFChanged>(centralForce));

			IForce interNodeForce = new Frontend.Physics.ForceInterNode(new Frontend.RegistryNodeAvatar(this.graph));
			this.fixedUpdatables.Add(interNodeForce);
			this.observers.Add(new Frontend.Physics.ForceFactorListener<EISliderInterNodeFChanged>(interNodeForce));

			IForce edgeForce = new Frontend.Physics.ForceEdge(new Frontend.RegistryEdgeAvatar(this.graph));
			this.fixedUpdatables.Add(edgeForce);
			this.observers.Add(new Frontend.Physics.ForceFactorListener<EISliderEdgeFChanged>(edgeForce));

			this.updatables.Add(Frontend.ForceCooler.GetInstance());
		}

		void setupInputScanners()
		{
			IDeviceInputScanner mouseDownScanner = new Frontend.UI.DeviceInputScanner(Input.GetMouseButtonDown);
			mouseDownScanner.addEvent<EILClick>(MButtons.LMB);
			mouseDownScanner.addEvent<EIStartCamRot>(MButtons.RMB);
			this.updatables.Add(mouseDownScanner);

			IDeviceInputScanner mouseUpScanner = new Frontend.UI.DeviceInputScanner(Input.GetMouseButtonUp);
			mouseUpScanner.addEvent<EIEndCamRot>(MButtons.RMB);
			this.updatables.Add(mouseUpScanner);
		}
	}
}