import React, { useState } from "react";
import MButton from "components/atoms/MButton/MButton";
import MText from "components/atoms/MText/MText";

interface ShoppingItem {
	id: number;
	name: string;
	quantity: number;
	completed: boolean;
}

const ShoppingList: React.FC = () => {
	const [items, setItems] = useState<ShoppingItem[]>([
		{ id: 1, name: "Milk", quantity: 1, completed: false },
		{ id: 2, name: "Eggs", quantity: 12, completed: false },
		{ id: 3, name: "Bread", quantity: 2, completed: true },
	]);

	const [newItemName, setNewItemName] = useState("");
	const [newItemQuantity, setNewItemQuantity] = useState(1);

	const handleToggleComplete = (id: number) => {
		setItems(
			items.map((item) =>
				item.id === id ? { ...item, completed: !item.completed } : item
			)
		);
	};

	const handleAddItem = (e: React.FormEvent) => {
		e.preventDefault();
		if (!newItemName.trim()) return;

		setItems([
			...items,
			{
				id: Date.now(),
				name: newItemName,
				quantity: newItemQuantity,
				completed: false,
			},
		]);

		setNewItemName("");
		setNewItemQuantity(1);
	};

	return (
		<div className="shopping-list-container">
			<div className="shopping-list-header">
				<MText text="Shopping List" as="h1" size="xl" weight="bold" />
				<MButton
					text="Add Item"
					onClick={handleAddItem}
					variant="primary"
				/>
			</div>
			<ul className="shopping-list-items">
				{items.map((item) => (
					<li key={item.id} className="shopping-list-item">
						<MText text={item.name} as="span" size="md" />
						<MButton
							text="Remove"
							onClick={() => handleToggleComplete(item.id)}
							variant="outlined"
							size="small"
						/>
					</li>
				))}
			</ul>
			<form onSubmit={handleAddItem}>
				<input
					type="text"
					value={newItemName}
					onChange={(e) => setNewItemName(e.target.value)}
					placeholder="Item name"
				/>
				<input
					type="number"
					min="1"
					value={newItemQuantity}
					onChange={(e) =>
						setNewItemQuantity(parseInt(e.target.value))
					}
				/>
				<button type="submit">Add Item</button>
			</form>
		</div>
	);
};

export default ShoppingList;
